using WeatherAPI.Controllers;
using Microsoft.Extensions.Logging;

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
      var data = currentAndDailyForcastController.GetCurrentAndDailyForcast("Alberton", null,null);
      Assert.AreEqual(data.City, "Alberton");
      Assert.IsTrue(data.Forcast.Count > 0);
    }

    [TestMethod()]
    public void GetTestCityProvinceTest()
    {
      var data = currentAndDailyForcastController.GetCurrentAndDailyForcast("Alberton", "Gauteng", null);
      Assert.AreEqual(data.City, "Alberton");
      Assert.AreEqual(data.Province, "Gauteng");
      Assert.IsTrue(data.Forcast.Count > 0);
    }

    [TestMethod()]
    public void GetCityCountryTest()
    {
      var data = currentAndDailyForcastController.GetCurrentAndDailyForcast("Alberton", null, "South Africa");
      Assert.AreEqual(data.City, "Alberton");
      Assert.AreEqual(data.Country, "South Africa");
      Assert.IsTrue(data.Forcast.Count > 0);
    }

    [TestMethod()]
    public void GetCityProvinceCountryTest()
    {
      var data = currentAndDailyForcastController.GetCurrentAndDailyForcast("Alberton", "Gauteng", "South Africa");
      Assert.AreEqual(data.City, "Alberton"); 
      Assert.AreEqual(data.Province, "Gauteng");
      Assert.AreEqual(data.Country, "South Africa");
      Assert.IsTrue(data.Forcast.Count > 0);
    }

    [TestMethod()]
    public void GetNoResultsCityProvinceCountryTest()
    {
      var data = currentAndDailyForcastController.GetCurrentAndDailyForcast("Alberton", "Eastern Cape", "South Africa");
      Assert.AreEqual(data,null);
    }

    [TestMethod()]
    public void GetNoResultsProvinceCountryTest()
    {
      var data = currentAndDailyForcastController.GetCurrentAndDailyForcast(null, "Gauteng", "South Africa");
      Assert.AreEqual(data, null);
    }

    [TestMethod()]
    public void GetNoResultsProvinceTest()
    {
      var data = currentAndDailyForcastController.GetCurrentAndDailyForcast(null, "Gauteng", null);
      Assert.AreEqual(data, null);
    }

    [TestMethod()]
    public void GetNoResultsCountryTest()
    {
      var data = currentAndDailyForcastController.GetCurrentAndDailyForcast(null,null, "South Africa");
      Assert.AreEqual(data, null);
    }
  }
}