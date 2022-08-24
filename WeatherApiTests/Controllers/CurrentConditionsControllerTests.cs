using WeatherAPI.Controllers;
using Microsoft.Extensions.Logging;

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
      var data = currentConditionsController.Get("Alberton", null,null);
      Assert.IsNotNull(data);

    }

    [TestMethod()]
    public void GetTestCityProvinceTest()
    {
      var data = currentConditionsController.Get("Alberton", "Gauteng", null);
      Assert.IsNotNull(data);
    }

    [TestMethod()]
    public void GetCityCountryTest()
    {
      var data = currentConditionsController.Get("Alberton", null, "South Africa");
      Assert.IsNotNull(data);
    }

    [TestMethod()]
    public void GetCityProvinceCountryTest()
    {
      var data = currentConditionsController.Get("Alberton", "Gauteng", "South Africa");
      Assert.IsNotNull(data);
    }

    [TestMethod()]
    public void GetNoResultsCityProvinceCountryTest()
    {
      var data = currentConditionsController.Get("Alberton", "Eastern Cape", "South Africa");
      Assert.AreEqual(data,null);
    }

    [TestMethod()]
    public void GetNoResultsProvinceCountryTest()
    {
      var data = currentConditionsController.Get(null, "Gauteng", "South Africa");
      Assert.AreEqual(data, null);
    }

    [TestMethod()]
    public void GetNoResultsProvinceTest()
    {
      var data = currentConditionsController.Get(null, "Gauteng", null);
      Assert.AreEqual(data, null);
    }

    [TestMethod()]
    public void GetNoResultsCountryTest()
    {
      var data = currentConditionsController.Get(null,null, "South Africa");
      Assert.AreEqual(data, null);
    }
  }
}