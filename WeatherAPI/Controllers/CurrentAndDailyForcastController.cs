﻿using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Model;
using Newtonsoft.Json;
using Accuweather.Current;

namespace WeatherAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CurrentAndDailyForcastController : ControllerBase
  {
    private Accuweather.AccuweatherApi _accuweatherApi;
    private readonly ILogger<CurrentAndDailyForcastController> _logger;

    public CurrentAndDailyForcastController(ILogger<CurrentAndDailyForcastController> logger)
    {
      _logger = logger;
      _accuweatherApi = new Accuweather.AccuweatherApi("X9R2u82JUWAlaYh9MAGP8hWGmCWIWv6l");
    }

    [HttpGet("byCity")]
    public CurrentAndDailyForcast GetAutoCompleteSearchByCity(string cityName)
    {
      List<Cities> cities = new List<Cities>();
      CurrentAndDailyForcast currentAndDailyForcast = new CurrentAndDailyForcast(); 
      var data = _accuweatherApi.Locations.AutoCompleteSearch(cityName).Result;

      if (data != null)
      {
        var citiesData = JsonConvert.DeserializeObject<CitiesResult>(data);
        cities = JsonConvert.DeserializeObject<List<Cities>>(citiesData.Data);
      }

      var result = cities.FirstOrDefault();

      currentAndDailyForcast.Key = result.Key;
      currentAndDailyForcast.City = result.LocalizedName;
      currentAndDailyForcast.Province = result.AdministrativeArea.LocalizedName;
      currentAndDailyForcast.Country = result.Country.LocalizedName;

      DailyForecastsRoot dailyForecastsRoot = new DailyForecastsRoot();
      data = _accuweatherApi.Forecast.FiveDaysOfDailyForecasts(Convert.ToInt32(result.Key), true, true).Result;

      if (data != null)
      {
        var currentConditionsResultResult = JsonConvert.DeserializeObject<DailyForecastsResult>(data);
        dailyForecastsRoot = JsonConvert.DeserializeObject<DailyForecastsRoot>(currentConditionsResultResult.Data);
      }

      currentAndDailyForcast.Forcast = new List<Forcast>();

      foreach (var dailyForcast in dailyForecastsRoot.DailyForecasts)
      {
        Forcast forcast = new Forcast();
        forcast.Sun = dailyForcast.Sun;
        forcast.Moon = dailyForcast.Moon;
        forcast.Date = dailyForcast.Date;
        forcast.RealFeelTemperature = dailyForcast.RealFeelTemperature;
        forcast.Temperature = dailyForcast.Temperature;
        forcast.ShortPhrase = dailyForcast.Day.ShortPhrase;
        currentAndDailyForcast.Forcast.Add(forcast); 
      }
      return currentAndDailyForcast;
    }

    //TODO: Complete Below to match top. 

    //[HttpGet("byCityProvince")]
    //public CurrentAndDailyForcast GetAutoCompleteSearchByCityProvince(string cityName, string provinceName)
    //{
    //  List<Cities> cities = new List<Cities>();
    //  CurrentAndDailyForcast currentAndDailyForcast = new CurrentAndDailyForcast();
    //  var data = _accuweatherApi.Locations.AutoCompleteSearch(cityName).Result;

    //  if (data != null)
    //  {
    //    var citiesData = JsonConvert.DeserializeObject<CitiesResult>(data);
    //    cities = JsonConvert.DeserializeObject<List<Cities>>(citiesData.Data);
    //  }

    //  var result = cities.FirstOrDefault(c => c.AdministrativeArea.LocalizedName.Equals(provinceName, StringComparison.InvariantCultureIgnoreCase));

    //  currentAndDailyForcast.Key = result.Key;
    //  currentAndDailyForcast.City = result.LocalizedName;
    //  currentAndDailyForcast.Province = result.AdministrativeArea.LocalizedName;
    //  currentAndDailyForcast.Country = result.Country.LocalizedName;

    //  return currentAndDailyForcast;
    //}


    //[HttpGet("byCityCountry")]
    //public CurrentAndDailyForcast GetAutoCompleteSearchByCityCountry(string cityName, string countryName)
    //{
    //  List<Cities> cities = new List<Cities>();
    //  CurrentAndDailyForcast currentAndDailyForcast = new CurrentAndDailyForcast();
    //  var data = _accuweatherApi.Locations.AutoCompleteSearch(cityName).Result;

    //  if (data != null)
    //  {
    //    var citiesData = JsonConvert.DeserializeObject<CitiesResult>(data);
    //    cities = JsonConvert.DeserializeObject<List<Cities>>(citiesData.Data);
    //  }

    //  var result = cities.FirstOrDefault(c => c.Country.LocalizedName.Equals(countryName, StringComparison.InvariantCultureIgnoreCase));

    //  currentAndDailyForcast.Key = result.Key;
    //  currentAndDailyForcast.City = result.LocalizedName;
    //  currentAndDailyForcast.Province = result.AdministrativeArea.LocalizedName;
    //  currentAndDailyForcast.Country = result.Country.LocalizedName;

    //  return currentAndDailyForcast;
    //}
  }
}