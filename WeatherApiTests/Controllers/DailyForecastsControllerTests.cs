using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using WeatherAPI.Controllers;
using WeatherAPI.Model;

namespace WeatherApiTests.Controllers
{
  [TestClass()]
  public class DailyForecastsControllerTests
  {
    private DailyForecastsController dailyForecastsController;

    public DailyForecastsControllerTests()
    {
      ILoggerFactory loggerFactory = new LoggerFactory();
      ILogger<DailyForecastsController> _logger = new Logger<DailyForecastsController>(loggerFactory);
      dailyForecastsController = new DailyForecastsController(_logger);
    }

    [TestMethod()]
    public void GetTest()
    {
      var data = dailyForecastsController.GetDailyForcasts("Alberton", null, null).Result;
      var objResult = data as OkObjectResult;
      var dailyForcast = objResult?.Value as DailyForecastsRoot;
      Assert.IsNotNull(dailyForcast);
      Assert.IsNotNull(dailyForcast?.Headline);
      Assert.IsNotNull(dailyForcast?.DailyForecasts);
    }

    [TestMethod()]
    public void GetTestCityProvinceTest()
    {
      var data = dailyForecastsController.GetDailyForcasts("Alberton", "Gauteng", null).Result;
      var objResult = data as OkObjectResult;
      var dailyForcast = objResult?.Value as DailyForecastsRoot;
      Assert.IsNotNull(dailyForcast);
      Assert.IsNotNull(dailyForcast?.Headline);
      Assert.IsNotNull(dailyForcast?.DailyForecasts);
    }

    [TestMethod()]
    public void GetCityCountryTest()
    {
      var data = dailyForecastsController.GetDailyForcasts("Alberton", null, "South Africa").Result;
      var objResult = data as OkObjectResult;
      var dailyForcast = objResult?.Value as DailyForecastsRoot;
      Assert.IsNotNull(dailyForcast);
      Assert.IsNotNull(dailyForcast?.Headline);
      Assert.IsNotNull(dailyForcast?.DailyForecasts);

    }

    [TestMethod()]
    public void GetCityProvinceCountryTest()
    {
      var data = dailyForecastsController.GetDailyForcasts("Alberton", "Gauteng", "South Africa").Result;
      var objResult = data as OkObjectResult;
      var dailyForcast = objResult?.Value as DailyForecastsRoot;
      Assert.IsNotNull(dailyForcast);
      Assert.IsNotNull(dailyForcast?.Headline);
      Assert.IsNotNull(dailyForcast?.DailyForecasts);
    }

    [TestMethod()]
    public void GetNoResultsCityProvinceCountryTest()
    {
      var data = dailyForecastsController.GetDailyForcasts("Alberton", "Eastern Cape", "South Africa").Result;
      var objResult = data as OkObjectResult;
      var dailyForcast = objResult?.Value as DailyForecastsRoot;
      Assert.AreEqual(dailyForcast?.DailyForecasts?.Count, 0);
    }

    [TestMethod()]
    public void GetNoResultsProvinceCountryTest()
    {
      var data = dailyForecastsController.GetDailyForcasts(null, "Gauteng", "South Africa").Result;
      var objResult = data as BadRequestObjectResult;
      Assert.AreEqual(objResult?.StatusCode, (int)HttpStatusCode.BadRequest);
    }

    [TestMethod()]
    public void GetNoResultsProvinceTest()
    {
      var data = dailyForecastsController.GetDailyForcasts(null, "Gauteng", null).Result;
      var objResult = data as BadRequestObjectResult;
      Assert.AreEqual(objResult?.StatusCode, (int)HttpStatusCode.BadRequest);
    }

    [TestMethod()]
    public void GetNoResultsCountryTest()
    {
      var data = dailyForecastsController.GetDailyForcasts(null, null, "South Africa").Result;
      var objResult = data as BadRequestObjectResult;
      Assert.AreEqual(objResult?.StatusCode, (int)HttpStatusCode.BadRequest);
    }
  }
}