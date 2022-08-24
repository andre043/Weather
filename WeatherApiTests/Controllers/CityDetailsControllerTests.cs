using WeatherAPI.Controllers;
using Microsoft.Extensions.Logging;

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
      var data = cityDetailsController.GetCityDetailsByCityCountry("Alberton", null,null);
      Assert.AreEqual(data?.FirstOrDefault().LocalizedName, "Alberton"); 
    }

    [TestMethod()]
    public void GetTestCityProvinceTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry("Alberton", "Gauteng", null);
      Assert.AreEqual(data?.FirstOrDefault().LocalizedName, "Alberton");
      Assert.AreEqual(data?.FirstOrDefault().AdministrativeArea.LocalizedName, "Gauteng");

    }

    [TestMethod()]
    public void GetCityCountryTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry("Alberton", null, "South Africa");
      Assert.AreEqual(data?.FirstOrDefault().LocalizedName, "Alberton");
      Assert.AreEqual(data?.FirstOrDefault().Country.LocalizedName, "South Africa");

    }

    [TestMethod()]
    public void GetCityProvinceCountryTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry("Alberton", "Gauteng", "South Africa");
      Assert.AreEqual(data?.FirstOrDefault().LocalizedName, "Alberton");
      Assert.AreEqual(data?.FirstOrDefault().AdministrativeArea.LocalizedName, "Gauteng");
      Assert.AreEqual(data?.FirstOrDefault().Country.LocalizedName, "South Africa");
    }

    [TestMethod()]
    public void GetNoResultsCityProvinceCountryTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry("Alberton", "Eastern Cape", "South Africa");
      Assert.AreEqual(data.Count, 0);
    }

    [TestMethod()]
    public void GetNoResultsProvinceCountryTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry(null, "Gauteng", "South Africa");
      Assert.AreEqual(data, null);
    }

    [TestMethod()]
    public void GetNoResultsProvinceTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry(null, "Gauteng", null);
      Assert.AreEqual(data, null);
    }

    [TestMethod()]
    public void GetNoResultsCountryTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry(null,null, "South Africa");
      Assert.AreEqual(data, null);
    }
  }
}