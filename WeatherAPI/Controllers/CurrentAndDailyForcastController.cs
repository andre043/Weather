﻿using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Helpers;
using WeatherAPI.Model;

namespace WeatherAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CurrentAndDailyForcastController : ControllerBase
  {
    private Accuweather.AccuweatherApi _accuweatherApi;
    private readonly ILogger<CurrentAndDailyForcastController> _logger;


    public CurrentAndDailyForcastController(ILogger<CurrentAndDailyForcastController> logger)
    {
      string apiKey = JsonConfigurationManager.AppSetting["ApiKey"];
      _logger = logger;
      _accuweatherApi = new Accuweather.AccuweatherApi(apiKey);
    }

    /// <summary>
    /// Searches and returns weather forcast for city name. Will return results for first city found.
    /// </summary>
    /// <param name="city">City Name</param>
    /// <returns></returns>
    [HttpGet("byCityProvinceCountry")]
    public CurrentAndDailyForcast GetCurrentAndDailyForcast(string city, string? province, string? country)
    {
      try
      {
        CurrentAndDailyForcast currentAndDailyForcast = new CurrentAndDailyForcast();

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

        //Helper class to minimize duplicate code. 
        CurrentAndDailyForcastHelper currentAndDailyForcastHelper = new CurrentAndDailyForcastHelper(_accuweatherApi);
        currentAndDailyForcast = currentAndDailyForcastHelper.PopulateCityDetails(cityDetails);
        currentAndDailyForcast.Forcast = currentAndDailyForcastHelper.GetForcast(Convert.ToInt32(cityDetails.Key));

        //Can assume postive data if the above runs successfully, error handeling in helper classes. 
        return currentAndDailyForcast;
      }
      catch (Exception e)
      {
        _logger.LogCritical(e, e.Message);
        return null;
      }
    }
  }
}