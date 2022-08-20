using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Model;
using Newtonsoft.Json;
using Accuweather.Current;

namespace WeatherAPI.Controllers
{
  [ApiController]
  [Route("/[controller]")]
  public class DailyForecastsController : ControllerBase
  {
    private Accuweather.AccuweatherApi _accuweatherApi;
    private readonly ILogger<DailyForecastsController> _logger;

    public DailyForecastsController(ILogger<DailyForecastsController> logger)
    {
      _logger = logger;
      _accuweatherApi = new Accuweather.AccuweatherApi("X9R2u82JUWAlaYh9MAGP8hWGmCWIWv6l");
    }

    [HttpGet("byCityProvince")]
    public List<DailyForecasts> Get(string city, string province)
    {
      List<Cities> cities = new List<Cities>();
      var data = _accuweatherApi.Locations.AutoCompleteSearch(city).Result;

      if (data != null)
      {
        var citiesData = JsonConvert.DeserializeObject<CitiesResult>(data);

        cities = JsonConvert.DeserializeObject<List<Cities>>(citiesData.Data);
      }

      string keyId = cities.FirstOrDefault(c => c.AdministrativeArea.LocalizedName.Equals(province, StringComparison.InvariantCultureIgnoreCase)).Key;


      List<DailyForecasts> dailyForecasts = new List<DailyForecasts>();
      data = _accuweatherApi.Forecast.FiveDaysOfDailyForecasts(Convert.ToInt32(keyId), true, true).Result;


      if (data != null)
      {
        var currentConditionsResultResult = JsonConvert.DeserializeObject<DailyForecastsResult>(data);
        dailyForecasts = JsonConvert.DeserializeObject<List<DailyForecasts>>(currentConditionsResultResult.Data);
      }

      return dailyForecasts;
    }
  }
}
