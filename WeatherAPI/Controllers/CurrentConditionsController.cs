using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
      _logger = logger;
      _accuweatherApi = new Accuweather.AccuweatherApi("X9R2u82JUWAlaYh9MAGP8hWGmCWIWv6l");
    }

    [HttpGet("byCityProvinceCountry")]
    public List<CurrentCondition> Get(string city, string? province, string? country)
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
