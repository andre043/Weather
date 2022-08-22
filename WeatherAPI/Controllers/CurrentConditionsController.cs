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
  public class CurrentConditionsController : ControllerBase
  {
    private Accuweather.AccuweatherApi _accuweatherApi;
    private readonly ILogger<CurrentConditionsController> _logger;
    private ResponseBase _responseBase;

    public CurrentConditionsController(ILogger<CurrentConditionsController> logger)
    {
      _responseBase = new ResponseBase();
      _logger = logger;
      _accuweatherApi = new Accuweather.AccuweatherApi("X9R2u82JUWAlaYh9MAGP8hWGmCWIWv6l");
    }

    [HttpGet("byCityProvinceCountry")]
    public ResponseBase Get(string city,string? province, string? country)
    {
      try
      {
        _responseBase.Data = new List<CurrentCondition>();

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


        List<CurrentCondition> currentCondition = new List<CurrentCondition>();
        var data = _accuweatherApi.CurrentConditions.Get(Convert.ToInt32(cityDetails.Key), true).Result;

        if (data != null)
        {
          var currentConditionsResultResult = JsonConvert.DeserializeObject<CurrentConditionResult>(data);

          if (currentConditionsResultResult.Data is null)
          {
            _responseBase.HttpStatusCode = HttpStatusCode.BadRequest;
            _responseBase.Message = $"No Result.data returned {city} from Acc API.";
            return _responseBase;
          }
          currentCondition = JsonConvert.DeserializeObject<List<CurrentCondition>>(currentConditionsResultResult.Data);
        }
        else
        {
          _responseBase.HttpStatusCode = HttpStatusCode.BadRequest;
          _responseBase.Message = $"Couldn't get forcast result for {city}.";
          return _responseBase;
        }

        if (currentCondition is null)
        {
          _responseBase.HttpStatusCode = HttpStatusCode.BadRequest;
          _responseBase.Message = $"No conditions returned for {city}.";
          return _responseBase;
        }

        //Can assume postive data if the above runs successfully, error handeling in helper classes. 
        _responseBase.HttpStatusCode = HttpStatusCode.OK;
        _responseBase.Message = "Success";
        _responseBase.Data = currentCondition;

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
