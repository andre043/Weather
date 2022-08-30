using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using WeatherAPI.Controllers;
using WeatherAPI.Model;

namespace WeatherApiTests.Controllers
{
  [TestClass()]
  public class CityDetailsControllerTests
  {
    private CityDetailsController cityDetailsController;

    public CityDetailsControllerTests()
    {
      ILoggerFactory loggerFactory = new LoggerFactory();
      ILogger<CityDetailsController> _logger = new Logger<CityDetailsController>(loggerFactory);
      cityDetailsController = new CityDetailsController(_logger);
    }

    [TestMethod()]
    public void GetTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry("Alberton", null, null).Result;
      var objResult = data as OkObjectResult;
      var cities = objResult?.Value as List<Cities>;
      Assert.AreEqual(cities?.FirstOrDefault().LocalizedName, "Alberton");
    }

    [TestMethod()]
    public void GetTestCityProvinceTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry("Alberton", "Gauteng", null).Result;
      var objResult = data as OkObjectResult;
      var cities = objResult?.Value as List<Cities>;
      Assert.AreEqual(cities?.FirstOrDefault().LocalizedName, "Alberton");
      Assert.AreEqual(cities?.FirstOrDefault().AdministrativeArea.LocalizedName, "Gauteng");
    }

    [TestMethod()]
    public void GetCityCountryTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry("Alberton", null, "South Africa").Result;
      var objResult = data as OkObjectResult;
      var cities = objResult?.Value as List<Cities>;
      Assert.AreEqual(cities?.FirstOrDefault().LocalizedName, "Alberton");
      Assert.AreEqual(cities?.FirstOrDefault().Country.LocalizedName, "South Africa");
    }

    [TestMethod()]
    public void GetCityProvinceCountryTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry("Alberton", "Gauteng", "South Africa").Result;
      var objResult = data as OkObjectResult;
      var cities = objResult?.Value as List<Cities>;
      Assert.AreEqual(cities?.FirstOrDefault().LocalizedName, "Alberton");
      Assert.AreEqual(cities?.FirstOrDefault().AdministrativeArea.LocalizedName, "Gauteng");
      Assert.AreEqual(cities?.FirstOrDefault().Country.LocalizedName, "South Africa");
    }

    [TestMethod()]
    public void GetNoResultsCityProvinceCountryTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry("Alberton", "Eastern Cape", "South Africa").Result;
      var objResult = data as OkObjectResult;
      var cities = objResult?.Value as List<Cities>;
      Assert.AreEqual(cities?.Count, 0);
    }

    [TestMethod()]
    public void GetNoResultsProvinceCountryTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry(null, "Gauteng", "South Africa").Result;
      var objResult = data as BadRequestObjectResult;
      Assert.AreEqual(objResult?.StatusCode, (int)HttpStatusCode.BadRequest);
    }

    [TestMethod()]
    public void GetNoResultsProvinceTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry(null, "Gauteng", null).Result;
      var objResult = data as BadRequestObjectResult;
      Assert.AreEqual(objResult?.StatusCode, (int)HttpStatusCode.BadRequest);
    }

    [TestMethod()]
    public void GetNoResultsCountryTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry(null, null, "South Africa").Result;
      var objResult = data as BadRequestObjectResult;
      Assert.AreEqual(objResult?.StatusCode, (int)HttpStatusCode.BadRequest);
    }
  }
}