using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WeatherAPI.Model;

namespace WeatherApiTests.Controllers
{
  [TestClass()]
  public class AutoSearchControllerTests
  {
    private AutoSearchController autoSearchController;

    public AutoSearchControllerTests()
    {
      ILoggerFactory loggerFactory = new LoggerFactory();
      ILogger<AutoSearchController> _logger = new Logger<AutoSearchController>(loggerFactory);
      autoSearchController = new AutoSearchController(_logger);
    }

    [TestMethod()]
    public void GetTest()
    {
      var area = autoSearchController.GetAutoCompleteSearchByCityProvince("Alberton","Gauteng");
      Assert.IsNotNull(area);
    }

    [TestMethod()]
    public void GetByAreaTest()
    {
      var area = autoSearchController.GetAutoCompleteSearchByCityProvince("Alberton", "Gauteng");
      Assert.AreEqual("Alberton", area?.LocalizedName);
      Assert.AreEqual("Gauteng", area?.AdministrativeArea.LocalizedName);
    }

    [TestMethod()]
    public void GetByAreaNegativeTest()
    {
      var area = autoSearchController.GetAutoCompleteSearchByCityProvince("", "");
      Assert.IsNull(area?.LocalizedName);
    }

    [TestMethod()]
    public void GetByAreaNegativeNoCityTest()
    {
      var area = autoSearchController.GetAutoCompleteSearchByCityProvince("", "Gauteng");
      Assert.IsNull(area?.LocalizedName);
    }

    [TestMethod()]
    public void GetByAreaNegativeNoProvinceTest()
    {
      var area = autoSearchController.GetAutoCompleteSearchByCityProvince("Alberton", "");
      Assert.IsNull(area?.LocalizedName);
    }
  }
}