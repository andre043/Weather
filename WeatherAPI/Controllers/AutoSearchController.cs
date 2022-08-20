using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Model;
using Newtonsoft.Json;
using Accuweather.Current;

namespace WeatherAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
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
    public List<Cities> GetAutoCompleteSearch(string cityName)
    {
      List<Cities> cities = new List<Cities>();
      var data = _accuweatherApi.Locations.AutoCompleteSearch(cityName).Result;

      if (data != null)
      {
        var citiesData = JsonConvert.DeserializeObject<CitiesResult>(data);

        cities = JsonConvert.DeserializeObject<List<Cities>>(citiesData.Data);
      }
      else 
      {
      //  _logger.
      }



      return cities;
    }

    [HttpGet("byCityProvince")]
    public Cities GetAutoCompleteSearchByCityProvince(string cityName, string provinceName)
    {
      List<Cities> cities = new List<Cities>();
      var data = _accuweatherApi.Locations.AutoCompleteSearch(cityName).Result;

      if (data != null)
      {
        var citiesData = JsonConvert.DeserializeObject<CitiesResult>(data);

        cities = JsonConvert.DeserializeObject<List<Cities>>(citiesData.Data);
      }

      return cities.FirstOrDefault(c => c.AdministrativeArea.LocalizedName.Equals(provinceName, StringComparison.InvariantCultureIgnoreCase));
    }
  }
}
