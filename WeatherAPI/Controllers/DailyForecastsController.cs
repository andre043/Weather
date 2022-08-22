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
  public class DailyForecastsController : ControllerBase
  {
    private Accuweather.AccuweatherApi _accuweatherApi;
    private readonly ILogger<DailyForecastsController> _logger;
    private ResponseBase _responseBase;

    public DailyForecastsController(ILogger<DailyForecastsController> logger)
    {
      _responseBase = new ResponseBase();
      _logger = logger;
      _accuweatherApi = new Accuweather.AccuweatherApi("X9R2u82JUWAlaYh9MAGP8hWGmCWIWv6l");
    }

    [HttpGet("byCityProvinceCountry")]
    public ResponseBase Get(string city, string? province, string? country)
    {
      try
      {
        _responseBase.Data = new DailyForecastsRoot();

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
        cityDetails = cityHelper.GetSpecificCity(cities, city, province, country);

        DailyForecastsRoot dailyForecastsRoot = new DailyForecastsRoot();
        var data = _accuweatherApi.Forecast.FiveDaysOfDailyForecasts(Convert.ToInt32(cityDetails.Key), true, true).Result;

        if (data != null)
        {
          var currentConditionsResultResult = JsonConvert.DeserializeObject<DailyForecastsResult>(data);

          if (currentConditionsResultResult.Data is null)
          {
            _responseBase.HttpStatusCode = HttpStatusCode.BadRequest;
            _responseBase.Message = $"No Result.data returned {city} from Acc API.";
            return _responseBase;
          }
          dailyForecastsRoot = JsonConvert.DeserializeObject<DailyForecastsRoot>(currentConditionsResultResult.Data);
        }
        else
        {
          _responseBase.HttpStatusCode = HttpStatusCode.BadRequest;
          _responseBase.Message = $"Couldn't get current conidtions result for {city}.";
          return _responseBase;
        }

        if (dailyForecastsRoot is null)
        {
          _responseBase.HttpStatusCode = HttpStatusCode.BadRequest;
          _responseBase.Message = $"No current conditions returned for {city}.";
          return _responseBase;
        }

        //Can assume postive data if the above runs successfully, error handeling in helper classes. 
        _responseBase.HttpStatusCode = HttpStatusCode.OK;
        _responseBase.Message = "Success";
        _responseBase.Data = dailyForecastsRoot;
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
