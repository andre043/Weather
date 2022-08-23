using Newtonsoft.Json;
using WeatherAPI.Model;


namespace WeatherAPI.Helpers
{
  public class CityHelper
  {
    private Accuweather.AccuweatherApi _accuweatherApi;
    public CityHelper(Accuweather.AccuweatherApi accuweatherApi)
    {
      _accuweatherApi = accuweatherApi;
    }

    /// <summary>
    /// Returns all cities matching or containing string passed through. 
    /// </summary>
    /// <param name="name">Name of city used for searching</param>
    /// <returns>List of cities which matches or contains search criteria</returns>
    /// <exception cref="Exception"></exception>
    public List<Cities> GetCities(string name)
    {
      try
      {
        List<Cities> cities = new List<Cities>();
        var data = _accuweatherApi.Locations.AutoCompleteSearch(name).Result;

        if (data != null)
        {
          var citiesData = JsonConvert.DeserializeObject<CitiesResult>(data);
          if (citiesData.Data != null)
          {
            cities = JsonConvert.DeserializeObject<List<Cities>>(citiesData.Data);
          }
          else
          {
            throw new Exception("Server Error. Incorrect Data from Accu Weather API.");
          }
        }
        else
        {
          throw new Exception("Server Error. Cannot reach Accu Weather API.");
        }

        if (cities.Count == 0)
        {
          throw new Exception("Server Error. No cities returned.");
        }
        return cities;
      }
      catch (Exception e)
      {
        throw new Exception("CityHelper.GetCities failed. See exception for more details.", e);
      }
    }

    public Cities GetSpecificCity(List<Cities> cities, string city, string? province, string? country)
    {
      try
      {
        //Ignore Variant and Culture to eliminate some possible bugs. 
        Cities cityDetail = new Cities();

        //Country, province and city is populated, therefor result should return one result. 
        if (!String.IsNullOrEmpty(province) && !String.IsNullOrEmpty(country))
        {
          cityDetail = cities.Where(c => c.Country.LocalizedName.Equals(country, StringComparison.InvariantCultureIgnoreCase) && c.AdministrativeArea.LocalizedName.Equals(province, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }
        //Only country and province,state is populated. Should only return one city. 
        else if (!String.IsNullOrEmpty(province))
        {
          cityDetail = cities.Where(c => c.AdministrativeArea.LocalizedName.Equals(province, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }
        //Only country and city is populated. Can return multiple cities. 
        else if (!String.IsNullOrEmpty(country))
        {
          cityDetail = cities.Where(c => c.Country.LocalizedName.Equals(country, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }
        //Only city is populated. 
        else
        {
          cityDetail = cities.FirstOrDefault();
        }

        if (cityDetail is null)
        {
          throw new Exception($"Failed To Get City with the following details City {city}, Provice/State {province}, Country {country}.");
        }
        return cityDetail;

      }
      catch (Exception e)
      {
        throw new Exception("CityHelper.GetSpecificCity failed. See exception for more details.", e);
      }
    }
  }
}
