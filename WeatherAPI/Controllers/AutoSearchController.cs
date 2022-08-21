using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Model;
using Newtonsoft.Json;
using Accuweather.Current;

namespace WeatherAPI.Controllers
{
  [ApiController]
  [Route("Cities/[controller]")]
  public class AutoSearchController : ControllerBase
  {
    private Accuweather.AccuweatherApi _accuweatherApi;
    private readonly ILogger<AutoSearchController> _logger;

    public AutoSearchController(ILogger<AutoSearchController> logger)
    {
      _logger = logger;
      _accuweatherApi = new Accuweather.AccuweatherApi("X9R2u82JUWAlaYh9MAGP8hWGmCWIWv6l");
    }

    [HttpGet("byCityName")]
    public List<Cities> GetAutoCompleteSearch(string city)
    {
      try
      {
        List<Cities> cities = new List<Cities>();
        var data = _accuweatherApi.Locations.AutoCompleteSearch(city).Result;

        if (data != null)
        {
          var citiesData = JsonConvert.DeserializeObject<CitiesResult>(data);

          cities = JsonConvert.DeserializeObject<List<Cities>>(citiesData.Data);
        }
        return cities;
      }
      catch (Exception e)
      {
        //if (e is BadRequestException || e is HttpRequestException || e is TimeoutRejectedException)
        //{
        //  // Log exception
        //}
        //else
        //{
        return null; 
        //}
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
