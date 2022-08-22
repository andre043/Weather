using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Model;
using Newtonsoft.Json;
using System.Net;
using WeatherAPI.Helpers;

namespace WeatherAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CityDetailsController : ControllerBase
  {
    private Accuweather.AccuweatherApi _accuweatherApi;
    private readonly ILogger<CityDetailsController> _logger;
    private ResponseBase _responseBase;

    public CityDetailsController(ILogger<CityDetailsController> logger)
    {
       string apiKey = JsonConfigurationManager.AppSetting["ApiKey"];
      _responseBase = new ResponseBase();
      _logger = logger;
      _accuweatherApi = new Accuweather.AccuweatherApi(apiKey);
    }

    /// <summary>
    /// Returns list of cities. To get specific list use provice or country to help narrow down the search. A Country may have more than city with same name. 
    /// </summary>
    /// <param name="city">City Name or Suburb</param>
    /// <param name="province">Allows NULLS. Province or State Name.</param>
    /// <param name="country">Allows NULLS. Country Name.</param>
    /// <returns></returns>
    [HttpGet("byCityProvinceCountry")]
    public ResponseBase GetCityDetailsByCityCountry(string city,string? province ,string? country)
    {
      try
      {
        CityHelper cityHelper = new CityHelper(_accuweatherApi);
        _responseBase.Data = new List<Cities>();
        //Just to double check no rubbish data is thrown. 
        if (String.IsNullOrEmpty(city))
        {
          _responseBase.HttpStatusCode = HttpStatusCode.BadRequest;
          _responseBase.Message = "No Value For City.";
          return _responseBase;
        }
        //Error handeling done inside method. If no error is thrown in method, then at least 1 record will always be returned. 
        var cities = cityHelper.GetCities(city);

        //Ignore Variant and Culture to eliminate some possible bugs. 
        List<Cities> cityDetail = new List<Cities>(); 

        //Country, province and city is populated, therefor result should return one result. 
        if (!String.IsNullOrEmpty(province) && !String.IsNullOrEmpty(country))
        {
          cityDetail = cities.Where(c => c.Country.LocalizedName.Equals(country, StringComparison.InvariantCultureIgnoreCase) && c.AdministrativeArea.LocalizedName.Equals(province, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
        //Only country and province,state is populated. Should only return one city. 
        else if (!String.IsNullOrEmpty(province))
        {
          cityDetail = cities.Where(c => c.AdministrativeArea.LocalizedName.Equals(province, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
        //Only country and city is populated. Can return multiple cities. 
        else if (!String.IsNullOrEmpty(country))
        {
          cityDetail = cities.Where(c => c.Country.LocalizedName.Equals(country, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
        //Only city is populated. 
        else 
        {
          cityDetail.Add(cities.FirstOrDefault());
        }
  
        //Just to confirm we found a match. User could input an incorrect country or provice,state. 
        if (cityDetail is null)
        {
          _responseBase.HttpStatusCode = HttpStatusCode.BadRequest;
          _responseBase.Message = "No City Found For Country.";
          return _responseBase;
        }

        _responseBase.Data = cityDetail;
        _responseBase.HttpStatusCode = HttpStatusCode.OK;
        _responseBase.Message = "Success";

        return _responseBase;
      }
      catch (Exception e)
      {
        _responseBase.HttpStatusCode = HttpStatusCode.InternalServerError;
        _responseBase.Message = e.InnerException?.ToString();
        _logger.LogCritical(e, e.Message);
        return _responseBase;
      }
    }
  }
}
