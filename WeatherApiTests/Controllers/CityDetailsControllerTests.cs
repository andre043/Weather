using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WeatherAPI.Model;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Net;

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
      var result = JsonConvert.DeserializeObject<List<Cities>>(data?.ToString());

    }

    [TestMethod()]
    public void GetTestCityProvinceTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry("Alberton", "Gauteng", null);
      var result = JsonConvert.DeserializeObject<List<Cities>>(data?.ToString());

    }

    [TestMethod()]
    public void GetCityCountryTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry("Alberton", null, "South Africa");
      var result = JsonConvert.DeserializeObject<List<Cities>>(data?.ToString());

    }

    [TestMethod()]
    public void GetCityProvinceCountryTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry("Alberton", "Gauteng", "South Africa");
      var result = JsonConvert.DeserializeObject<List<Cities>>(data?.ToString());

    }

    [TestMethod()]
    public void GetNoResultsCityProvinceCountryTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry("Alberton", "Eastern Cape", "South Africa");
      var result = JsonConvert.DeserializeObject<List<Cities>>(data?.ToString());

    }

    [TestMethod()]
    public void GetNoResultsProvinceCountryTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry(null, "Gauteng", "South Africa");
      var result = JsonConvert.DeserializeObject<List<Cities>>(data?.ToString());

    }

    [TestMethod()]
    public void GetNoResultsProvinceTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry(null, "Gauteng", null);
      var result = JsonConvert.DeserializeObject<List<Cities>>(data?.ToString());

    }

    [TestMethod()]
    public void GetNoResultsCountryTest()
    {
      var data = cityDetailsController.GetCityDetailsByCityCountry(null,null, "South Africa");
      var result = JsonConvert.DeserializeObject<List<Cities>>(data?.ToString());

    }
  }
}