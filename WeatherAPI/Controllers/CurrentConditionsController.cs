using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using WeatherAPI.Helpers;
using WeatherAPI.Model;

namespace WeatherAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CurrentConditionsController : ControllerBase
  {
    private Accuweather.AccuweatherApi _accuweatherApi;
    private readonly ILogger<CurrentConditionsController> _logger;

    public CurrentConditionsController(ILogger<CurrentConditionsController> logger)
    {
      //API Key Is Stored In App Settings so that it is easy to change. 
      string apiKey = JsonConfigurationManager.AppSetting["ApiKey"];
      _logger = logger;
      _accuweatherApi = new Accuweather.AccuweatherApi(apiKey);
    }

    /// <summary>
    /// Returns current conidtions for a city.
    /// </summary>
    /// <param name="city">City Name. Is Required</param>
    /// <param name="province">Allows NULLS. Province or State Name.</param>
    /// <param name="country">Allows NULLS. Country Name.</param>
    /// <returns></returns>
    [HttpGet("byCityProvinceCountry")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public List<CurrentCondition> GetCurrentConditions([Required] string city, string? province, string? country)
    {
      try
      {
        //Helper class to minimize duplicate code. 
        CityHelper cityHelper = new CityHelper(_accuweatherApi);
        List<Cities> cities = cityHelper.GetCities(city);

        if (cities is null)
        {
          throw new Exception($"No city was found for {city}.");
        }

        //Get one city from list to work with. 
        Cities cityDetails = new Cities();
        cityDetails = cityHelper.GetSpecificCity(cities, city, province, country);


        List<CurrentCondition> currentCondition = new List<CurrentCondition>();
        var data = _accuweatherApi.CurrentConditions.Get(Convert.ToInt32(cityDetails.Key), true).Result;
        //Check to make sure we got data back
        if (data != null)
        {
          var currentConditionsResultResult = JsonConvert.DeserializeObject<CurrentConditionResult>(data);

          if (currentConditionsResultResult.Data is null)
          {
            throw new Exception($"No Result.data returned {city} from Acc API.");

          }
          currentCondition = JsonConvert.DeserializeObject<List<CurrentCondition>>(currentConditionsResultResult.Data);
        }
        else
        {
          throw new Exception($"Couldn't get forcast result for {city}.");

        }

        if (currentCondition is null)
        {
          throw new Exception($"No conditions returned for {city}.");
        }

        return currentCondition;
      }
      catch (Exception e)
      {
        _logger.LogCritical(e, e.Message);
        return null;
      }
    }
  }
}
