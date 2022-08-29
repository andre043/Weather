using Microsoft.Extensions.Logging;
using WeatherAPI.Controllers;

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
      var data = dailyForecastsController.GetDailyForcasts("Alberton", null, null);
      Assert.IsNotNull(data);
      Assert.IsNotNull(data.Headline);
      Assert.IsNotNull(data.DailyForecasts);
    }

    [TestMethod()]
    public void GetTestCityProvinceTest()
    {
      var data = dailyForecastsController.GetDailyForcasts("Alberton", "Gauteng", null);
      Assert.IsNotNull(data);
      Assert.IsNotNull(data.Headline);
      Assert.IsNotNull(data.DailyForecasts);

    }

    [TestMethod()]
    public void GetCityCountryTest()
    {
      var data = dailyForecastsController.GetDailyForcasts("Alberton", null, "South Africa");
      Assert.IsNotNull(data);
      Assert.IsNotNull(data.Headline);
      Assert.IsNotNull(data.DailyForecasts);

    }

    [TestMethod()]
    public void GetCityProvinceCountryTest()
    {
      var data = dailyForecastsController.GetDailyForcasts("Alberton", "Gauteng", "South Africa");
      Assert.IsNotNull(data);
      Assert.IsNotNull(data.Headline);
      Assert.IsNotNull(data.DailyForecasts);
    }

    [TestMethod()]
    public void GetNoResultsCityProvinceCountryTest()
    {
      var data = dailyForecastsController.GetDailyForcasts("Alberton", "Eastern Cape", "South Africa");
      Assert.IsNull(data);
    }

    [TestMethod()]
    public void GetNoResultsProvinceCountryTest()
    {
      var data = dailyForecastsController.GetDailyForcasts(null, "Gauteng", "South Africa");
      Assert.IsNull(data);
    }

    [TestMethod()]
    public void GetNoResultsProvinceTest()
    {
      var data = dailyForecastsController.GetDailyForcasts(null, "Gauteng", null);
      Assert.IsNull(data);
    }

    [TestMethod()]
    public void GetNoResultsCountryTest()
    {
      var data = dailyForecastsController.GetDailyForcasts(null, null, "South Africa");
      Assert.IsNull(data);
    }
  }
}