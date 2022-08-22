using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Model;
using Newtonsoft.Json;
using Accuweather.Current;
using System.Net;
using WeatherAPI.Helpers;

namespace WeatherAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CurrentAndDailyForcastController : ControllerBase
  {
    private Accuweather.AccuweatherApi _accuweatherApi;
    private readonly ILogger<CurrentAndDailyForcastController> _logger;
    private ResponseBase _responseBase;

    public CurrentAndDailyForcastController(ILogger<CurrentAndDailyForcastController> logger)
    {
      _responseBase = new ResponseBase();
      _logger = logger;
      _accuweatherApi = new Accuweather.AccuweatherApi("X9R2u82JUWAlaYh9MAGP8hWGmCWIWv6l");
    }

    /// <summary>
    /// Searches and returns weather forcast for city name. Will return results for first city found.
    /// </summary>
    /// <param name="city">City Name</param>
    /// <returns></returns>
    [HttpGet("byCityProvinceCountry")]
    public ResponseBase GetCurrentAndDailyForcast(string city, string? province, string? country)
    {
      try
      {
        CurrentAndDailyForcast currentAndDailyForcast = new CurrentAndDailyForcast();
        _responseBase.Data = new CurrentAndDailyForcast();

        //Helper class to minimize duplicate code. 
        CityHelper cityHelper = new CityHelper(_accuweatherApi);
        List<Cities> cities = cityHelper.GetCities(city);

        if (cities is null)
        {
          _responseBase.HttpStatusCode = HttpStatusCode.BadRequest;
          _responseBase.Message = $"No city was found for {city}.";
          return _responseBase;
        }

        //Get one city from list to work with. 
        Cities cityDetails = new Cities();
        cityDetails = cityHelper.GetSpecificCity(cities,city,province, country);

        //Helper class to minimize duplicate code. 
        CurrentAndDailyForcastHelper currentAndDailyForcastHelper = new CurrentAndDailyForcastHelper(_accuweatherApi);
        currentAndDailyForcast = currentAndDailyForcastHelper.PopulateCityDetails(cityDetails);
        currentAndDailyForcast.Forcast = currentAndDailyForcastHelper.GetForcast(Convert.ToInt32(cityDetails.Key));

        //Can assume postive data if the above runs successfully, error handeling in helper classes. 
        _responseBase.HttpStatusCode = HttpStatusCode.OK;
        _responseBase.Message = "Success";
        _responseBase.Data = currentAndDailyForcast;
        return _responseBase;
      }
      catch (Exception e)
      {
        _responseBase.HttpStatusCode = HttpStatusCode.InternalServerError;
        _responseBase.Message = e.Message;
        _logger.LogCritical(e, e.Message);
        return _responseBase;
      }
    }
  }
}