using WeatherAPI.Controllers;
using Microsoft.Extensions.Logging;

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
      var data = dailyForecastsController.Get("Alberton", null,null);
      Assert.IsNotNull(data);
      Assert.IsNotNull(data.Headline);
      Assert.IsNotNull(data.DailyForecasts);
    }

    [TestMethod()]
    public void GetTestCityProvinceTest()
    {
      var data = dailyForecastsController.Get("Alberton", "Gauteng", null);
      Assert.IsNotNull(data);
      Assert.IsNotNull(data.Headline);
      Assert.IsNotNull(data.DailyForecasts);

    }

    [TestMethod()]
    public void GetCityCountryTest()
    {
      var data = dailyForecastsController.Get("Alberton", null, "South Africa");
      Assert.IsNotNull(data);
      Assert.IsNotNull(data.Headline);
      Assert.IsNotNull(data.DailyForecasts);

    }

    [TestMethod()]
    public void GetCityProvinceCountryTest()
    {
      var data = dailyForecastsController.Get("Alberton", "Gauteng", "South Africa");
      Assert.IsNotNull(data);
      Assert.IsNotNull(data.Headline);
      Assert.IsNotNull(data.DailyForecasts);
    }

    [TestMethod()]
    public void GetNoResultsCityProvinceCountryTest()
    {
      var data = dailyForecastsController.Get("Alberton", "Eastern Cape", "South Africa");
      Assert.IsNull(data);
      Assert.IsNull(data.Headline);
      Assert.IsNull(data.DailyForecasts);
    }

    [TestMethod()]
    public void GetNoResultsProvinceCountryTest()
    {
      var data = dailyForecastsController.Get(null, "Gauteng", "South Africa");
      Assert.IsNull(data);
      Assert.IsNull(data.Headline);
      Assert.IsNull(data.DailyForecasts);
    }

    [TestMethod()]
    public void GetNoResultsProvinceTest()
    {
      var data = dailyForecastsController.Get(null, "Gauteng", null);
      Assert.IsNull(data);
      Assert.IsNull(data.Headline);
      Assert.IsNull(data.DailyForecasts);
    }

    [TestMethod()]
    public void GetNoResultsCountryTest()
    {
      var data = dailyForecastsController.Get(null,null, "South Africa");
      Assert.IsNull(data);
      Assert.IsNull(data.Headline);
      Assert.IsNull(data.DailyForecasts); 
    }
  }
}