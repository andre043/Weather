using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using WeatherAPI.Controllers;
using WeatherAPI.Model;

namespace WeatherApiTests.Controllers
{
  [TestClass()]
  public class CurrentConditionsControllerTests
  {
    private CurrentConditionsController currentConditionsController;

    public CurrentConditionsControllerTests()
    {
      ILoggerFactory loggerFactory = new LoggerFactory();
      ILogger<CurrentConditionsController> _logger = new Logger<CurrentConditionsController>(loggerFactory);
      currentConditionsController = new CurrentConditionsController(_logger);
    }

    [TestMethod()]
    public void GetTest()
    {
      var data = currentConditionsController.GetCurrentConditions("Alberton", null, null).Result;
      var objResult = data as OkObjectResult;
      var current = objResult?.Value as List<CurrentCondition>;
      Assert.IsNotNull(current);
    }

    [TestMethod()]
    public void GetTestCityProvinceTest()
    {
      var data = currentConditionsController.GetCurrentConditions("Alberton", "Gauteng", null).Result;
      var objResult = data as OkObjectResult;
      var current = objResult?.Value as List<CurrentCondition>;
      Assert.IsNotNull(current);
    }

    [TestMethod()]
    public void GetCityCountryTest()
    {
      var data = currentConditionsController.GetCurrentConditions("Alberton", null, "South Africa").Result;
      var objResult = data as OkObjectResult;
      var current = objResult?.Value as List<CurrentCondition>;
      Assert.IsNotNull(current);
    }

    [TestMethod()]
    public void GetCityProvinceCountryTest()
    {
      var data = currentConditionsController.GetCurrentConditions("Alberton", "Gauteng", "South Africa").Result;
      var objResult = data as OkObjectResult;
      var current = objResult?.Value as List<CurrentCondition>;
      Assert.IsNotNull(current);
    }

    [TestMethod()]
    public void GetNoResultsCityProvinceCountryTest()
    {
      var data = currentConditionsController.GetCurrentConditions("Alberton", "Eastern Cape", "South Africa").Result;
      var objResult = data as OkObjectResult;
      var current = objResult?.Value as List<CurrentCondition>;
      Assert.AreEqual(current?.Count, 0);
    }

    [TestMethod()]
    public void GetNoResultsProvinceCountryTest()
    {
      var data = currentConditionsController.GetCurrentConditions(null, "Gauteng", "South Africa").Result;
      var objResult = data as BadRequestObjectResult;
      Assert.AreEqual(objResult?.StatusCode, (int)HttpStatusCode.BadRequest);
    }

    [TestMethod()]
    public void GetNoResultsProvinceTest()
    {
      var data = currentConditionsController.GetCurrentConditions(null, "Gauteng", null).Result;
      var objResult = data as BadRequestObjectResult;
      Assert.AreEqual(objResult?.StatusCode, (int)HttpStatusCode.BadRequest);
    }

    [TestMethod()]
    public void GetNoResultsCountryTest()
    {
      var data = currentConditionsController.GetCurrentConditions(null, null, "South Africa").Result;
      var objResult = data as BadRequestObjectResult;
      Assert.AreEqual(objResult?.StatusCode, (int)HttpStatusCode.BadRequest);
    }
  }
}