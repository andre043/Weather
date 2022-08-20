using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Model;
using Newtonsoft.Json;
using Accuweather.Current;

namespace WeatherAPI.Controllers
{
  [ApiController]
  [Route("/[controller]")]
  public class CurrentConditionsController : ControllerBase
  {
    private Accuweather.AccuweatherApi _accuweatherApi;
    private readonly ILogger<CurrentConditionsController> _logger;

    public CurrentConditionsController(ILogger<CurrentConditionsController> logger)
    {
      _logger = logger;
      _accuweatherApi = new Accuweather.AccuweatherApi("X9R2u82JUWAlaYh9MAGP8hWGmCWIWv6l");
    }

    [HttpGet("byKeyId")]
    public List<CurrentCondition> Get(string keyId)
    {
      List<CurrentCondition> currentCondition = new List<CurrentCondition>();
      var data = _accuweatherApi.CurrentConditions.Get(Convert.ToInt32(keyId)).Result;

      if (data != null)
      {
        var currentConditionsResultResult = JsonConvert.DeserializeObject<CurrentConditionResult>(data);
        currentCondition = JsonConvert.DeserializeObject<List<CurrentCondition>>(currentConditionsResultResult.Data);

      }
      return currentCondition;
    }


    [HttpGet("byCityProvince")]
    public List<CurrentCondition> Get(string city,string province)
    {
      List<Cities> cities = new List<Cities>();
      var data = _accuweatherApi.Locations.AutoCompleteSearch(city).Result;

      if (data != null)
      {
        var citiesData = JsonConvert.DeserializeObject<CitiesResult>(data);

        cities = JsonConvert.DeserializeObject<List<Cities>>(citiesData.Data);
      }

      string keyId = cities.FirstOrDefault(c => c.AdministrativeArea.LocalizedName.Equals(province, StringComparison.InvariantCultureIgnoreCase)).Key;

      List<CurrentCondition> currentCondition = new List<CurrentCondition>();
      data = _accuweatherApi.CurrentConditions.Get(Convert.ToInt32(keyId),true).Result;

      if (data != null)
      {
        var currentConditionsResultResult = JsonConvert.DeserializeObject<CurrentConditionResult>(data);
        currentCondition = JsonConvert.DeserializeObject<List<CurrentCondition>>(currentConditionsResultResult.Data);

      }

      _logger.LogInformation("Current Conditions Called");
      return currentCondition;
    }
  }
}
