using Microsoft.Extensions.Logging;
using WeatherAPI.Controllers;

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
      var data = currentConditionsController.GetCurrentConditions("Alberton", null, null);
      Assert.IsNotNull(data);
    }

    [TestMethod()]
    public void GetTestCityProvinceTest()
    {
      var data = currentConditionsController.GetCurrentConditions("Alberton", "Gauteng", null);
      Assert.IsNotNull(data);
    }

    [TestMethod()]
    public void GetCityCountryTest()
    {
      var data = currentConditionsController.GetCurrentConditions("Alberton", null, "South Africa");
      Assert.IsNotNull(data);
    }

    [TestMethod()]
    public void GetCityProvinceCountryTest()
    {
      var data = currentConditionsController.GetCurrentConditions("Alberton", "Gauteng", "South Africa");
      Assert.IsNotNull(data);
    }

    [TestMethod()]
    public void GetNoResultsCityProvinceCountryTest()
    {
      var data = currentConditionsController.GetCurrentConditions("Alberton", "Eastern Cape", "South Africa");
      Assert.AreEqual(data, null);
    }

    [TestMethod()]
    public void GetNoResultsProvinceCountryTest()
    {
      var data = currentConditionsController.GetCurrentConditions(null, "Gauteng", "South Africa");
      Assert.AreEqual(data, null);
    }

    [TestMethod()]
    public void GetNoResultsProvinceTest()
    {
      var data = currentConditionsController.GetCurrentConditions(null, "Gauteng", null);
      Assert.AreEqual(data, null);
    }

    [TestMethod()]
    public void GetNoResultsCountryTest()
    {
      var data = currentConditionsController.GetCurrentConditions(null, null, "South Africa");
      Assert.AreEqual(data, null);
    }
  }
}