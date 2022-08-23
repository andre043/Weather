using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherAPI.Helpers;
using WeatherAPI.Model;

namespace WeatherAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DailyForecastsController : ControllerBase
  {
    private Accuweather.AccuweatherApi _accuweatherApi;
    private readonly ILogger<DailyForecastsController> _logger;

    public DailyForecastsController(ILogger<DailyForecastsController> logger)
    {
      _logger = logger;
      _accuweatherApi = new Accuweather.AccuweatherApi("X9R2u82JUWAlaYh9MAGP8hWGmCWIWv6l");
    }

    [HttpGet("byCityProvinceCountry")]
    public DailyForecastsRoot Get(string city, string? province, string? country)
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

        DailyForecastsRoot dailyForecastsRoot = new DailyForecastsRoot();
        var data = _accuweatherApi.Forecast.FiveDaysOfDailyForecasts(Convert.ToInt32(cityDetails.Key), true, true).Result;

        if (data != null)
        {
          var currentConditionsResultResult = JsonConvert.DeserializeObject<DailyForecastsResult>(data);

          if (currentConditionsResultResult.Data is null)
          {
            throw new Exception($"No Result.data returned {city} from Acc API.");
          }
          dailyForecastsRoot = JsonConvert.DeserializeObject<DailyForecastsRoot>(currentConditionsResultResult.Data);
        }
        else
        {
          throw new Exception($"Couldn't get current conidtions result for {city}.");
        }

        if (dailyForecastsRoot is null)
        {
          throw new Exception($"No current conditions returned for {city}.");

        }

        //Can assume postive data if the above runs successfully, error handeling in helper classes. 
        return dailyForecastsRoot;
      }
      catch (Exception e)
      {
        _logger.LogCritical(e, e.Message);
        return null;
      }
    }
  }
}
