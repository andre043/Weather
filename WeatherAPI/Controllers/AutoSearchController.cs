using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Model;
using Newtonsoft.Json;
using Accuweather.Current;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.Net;
using System.Web;
using System.Net.Http;


namespace WeatherAPI.Controllers
{
  [ApiController]
  [Route("Cities/[controller]")]
  public class AutoSearchController : ControllerBase
  {
    private Accuweather.AccuweatherApi _accuweatherApi;
    private readonly ILogger<AutoSearchController> _logger;
    private ResponseBase _responseBase { get; }


    public AutoSearchController(ILogger<AutoSearchController> logger)
    {
      _logger = logger;
      _accuweatherApi = new Accuweather.AccuweatherApi("X9R2u82JUWAlaYh9MAGP8hWGmCWIWv6l");
    }

    [HttpGet("byCity")]
    public ResponseBase GetAutoCompleteSearch(string city)
    {
      try
      {
        List<Cities> cities = new List<Cities>();
        _responseBase.Data = new List<Cities>();

        var data = _accuweatherApi.Locations.AutoCompleteSearch(city).Result;

        if (data != null)
        {
          var citiesData = JsonConvert.DeserializeObject<CitiesResult>(data);

          cities = JsonConvert.DeserializeObject<List<Cities>>(citiesData.Data);
        }
        else
        {
          _responseBase.HttpStatusCode = HttpStatusCode.InternalServerError;
          _responseBase.Message = "Server Error";
          return _responseBase;
        }

        if (cities.Count == 0)
        {
          _responseBase.HttpStatusCode = HttpStatusCode.BadRequest;
          _responseBase.Message = "Invalid City";
          return _responseBase; 
        }
        _responseBase.HttpStatusCode = HttpStatusCode.Accepted;
        _responseBase.Message = "Success";
        _responseBase.Data = cities; 

        return _responseBase;
      }
      catch (Exception e)
      {
        _responseBase.HttpStatusCode = HttpStatusCode.InternalServerError;
        _responseBase.Message = e.Message;
        return _responseBase;
      }
    }

    [HttpGet("byCityProvince")]
    public Cities GetAutoCompleteSearchByCityProvince(string city, string province)
    {
      List<Cities> cities = new List<Cities>();
      var data = _accuweatherApi.Locations.AutoCompleteSearch(city).Result;

      if (data != null)
      {
        var citiesData = JsonConvert.DeserializeObject<CitiesResult>(data);

        cities = JsonConvert.DeserializeObject<List<Cities>>(citiesData.Data);
      }

      return cities.FirstOrDefault(c => c.AdministrativeArea.LocalizedName.Equals(province, StringComparison.InvariantCultureIgnoreCase));
    }
  }
}
