using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using WeatherAPI.Controllers;
using WeatherAPI.Model;

namespace WeatherApiTests.Controllers
{
  [TestClass()]
  public class CurrentAndDailyForcastControllerTests
  {
    private CurrentAndDailyForcastController currentAndDailyForcastController;

    public CurrentAndDailyForcastControllerTests()
    {
      ILoggerFactory loggerFactory = new LoggerFactory();
      ILogger<CurrentAndDailyForcastController> _logger = new Logger<CurrentAndDailyForcastController>(loggerFactory);
      currentAndDailyForcastController = new CurrentAndDailyForcastController(_logger);
    }

    [TestMethod()]
    public void GetTest()
    {
      var data = currentAndDailyForcastController.GetCurrentAndDailyForcast("Alberton", null, null).Result;
      var objResult = data as OkObjectResult;
      var currentAndDaily = objResult?.Value as CurrentAndDailyForcast;
      Assert.AreEqual(currentAndDaily?.City, "Alberton");
      Assert.IsTrue(currentAndDaily?.Forcast.Count > 0);
    }

    [TestMethod()]
    public void GetTestCityProvinceTest()
    {
      var data = currentAndDailyForcastController.GetCurrentAndDailyForcast("Alberton", "Gauteng", null).Result;
      var objResult = data as OkObjectResult;
      var currentAndDaily = objResult?.Value as CurrentAndDailyForcast;
      Assert.AreEqual(currentAndDaily?.City, "Alberton");
      Assert.AreEqual(currentAndDaily?.Province, "Gauteng");
      Assert.IsTrue(currentAndDaily?.Forcast.Count > 0);
    }

    [TestMethod()]
    public void GetCityCountryTest()
    {
      var data = currentAndDailyForcastController.GetCurrentAndDailyForcast("Alberton", null, "South Africa").Result;
      var objResult = data as OkObjectResult;
      var currentAndDaily = objResult?.Value as CurrentAndDailyForcast;
      Assert.AreEqual(currentAndDaily?.City, "Alberton");
      Assert.AreEqual(currentAndDaily?.Country, "South Africa");
      Assert.IsTrue(currentAndDaily?.Forcast.Count > 0);
    }

    [TestMethod()]
    public void GetCityProvinceCountryTest()
    {
      var data = currentAndDailyForcastController.GetCurrentAndDailyForcast("Alberton", "Gauteng", "South Africa").Result;
      var objResult = data as OkObjectResult;
      var currentAndDaily = objResult?.Value as CurrentAndDailyForcast;
      Assert.AreEqual(currentAndDaily?.City, "Alberton");
      Assert.AreEqual(currentAndDaily?.Country, "South Africa");
      Assert.IsTrue(currentAndDaily?.Forcast.Count > 0);
    }

    [TestMethod()]
    public void GetNoResultsCityProvinceCountryTest()
    {
      var data = currentAndDailyForcastController.GetCurrentAndDailyForcast("Alberton", "Eastern Cape", "South Africa").Result;
      var objResult = data as OkObjectResult;
      var currentAndDaily = objResult?.Value as CurrentAndDailyForcast;
      Assert.AreEqual(currentAndDaily?.City, "Alberton");
      Assert.AreEqual(currentAndDaily?.Province, "Gauteng");
      Assert.AreEqual(currentAndDaily?.Country, "South Africa");
      Assert.IsTrue(currentAndDaily?.Forcast.Count > 0);
    }

    [TestMethod()]
    public void GetNoResultsProvinceCountryTest()
    {
      var data = currentAndDailyForcastController.GetCurrentAndDailyForcast(null, "Gauteng", "South Africa").Result;
      var objResult = data as BadRequestObjectResult;
      Assert.AreEqual(objResult?.StatusCode, (int)HttpStatusCode.BadRequest);
    }

    [TestMethod()]
    public void GetNoResultsProvinceTest()
    {
      var data = currentAndDailyForcastController.GetCurrentAndDailyForcast(null, "Gauteng", null).Result;
      var objResult = data as BadRequestObjectResult;
      Assert.AreEqual(objResult?.StatusCode, (int)HttpStatusCode.BadRequest);
    }

    [TestMethod()]
    public void GetNoResultsCountryTest()
    {
      var data = currentAndDailyForcastController.GetCurrentAndDailyForcast(null, null, "South Africa").Result;
      var objResult = data as BadRequestObjectResult;
      Assert.AreEqual(objResult?.StatusCode, (int)HttpStatusCode.BadRequest);
    }
  }
}