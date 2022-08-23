using Newtonsoft.Json;
using WeatherAPI.Model;

namespace WeatherAPI.Helpers
{
  public class CurrentAndDailyForcastHelper
  {
    private Accuweather.AccuweatherApi _accuweatherApi;
    public CurrentAndDailyForcastHelper(Accuweather.AccuweatherApi accuweatherApi)
    {
      _accuweatherApi = accuweatherApi;
    }


    public CurrentAndDailyForcast PopulateCityDetails(Cities city)
    {
      try
      {
        CurrentAndDailyForcast currentAndDailyForcast = new CurrentAndDailyForcast();
        currentAndDailyForcast.Key = city.Key;
        currentAndDailyForcast.City = city.LocalizedName;
        currentAndDailyForcast.Province = city.AdministrativeArea.LocalizedName;
        currentAndDailyForcast.Country = city.Country.LocalizedName;
        return currentAndDailyForcast;
      }
      catch (Exception e)
      {
        throw new Exception("CurrentAndDailyForcastHelper.PopulateCityDetails failed.", e);
      }
    }


    public List<Forcast> GetForcast(int key)
    {
      try
      {
        List<Forcast> forcastResult = new List<Forcast>();
        DailyForecastsRoot dailyForecastsRoot = new DailyForecastsRoot();

        var data = _accuweatherApi.Forecast.FiveDaysOfDailyForecasts(key, true, true).Result;

        if (data != null)
        {
          var currentConditionsResultResult = JsonConvert.DeserializeObject<DailyForecastsResult>(data);

          if (currentConditionsResultResult?.Data is null)
          {
            throw new Exception("currentConditionsResultResult.Data is null.");
          }
          dailyForecastsRoot = JsonConvert.DeserializeObject<DailyForecastsRoot>(currentConditionsResultResult.Data);
        }
        else
        {
          throw new Exception("No Current Conidtions received from AccWeather API.");
        }

        if (dailyForecastsRoot?.DailyForecasts is null)
        {
          throw new Exception("No Daily Forecasts received from AccWeather API.");
        }

        forcastResult = new List<Forcast>();

        foreach (var dailyForcast in dailyForecastsRoot.DailyForecasts)
        {
          Forcast forcast = new Forcast();
          forcast.Sun = dailyForcast.Sun;
          forcast.Moon = dailyForcast.Moon;
          forcast.Date = dailyForcast.Date;
          forcast.RealFeelTemperature = dailyForcast.RealFeelTemperature;
          forcast.Temperature = dailyForcast.Temperature;
          forcast.ShortPhrase = dailyForcast.Day.ShortPhrase;
          forcastResult.Add(forcast);
        }

        return forcastResult;
      }
      catch (Exception e)
      {
        throw new Exception("CurrentAndDailyForcastHelper.GetForcast failed with", e);
      }
    }
  }
}
