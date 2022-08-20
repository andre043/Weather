//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using WeatherApiV2.Controllers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Logging;

//namespace WeatherApiTests.Controllers
//{
//  [TestClass()]
//  public class RegionControllerTests
//  {
//    private RegionController regionController;

//    public RegionControllerTests()
//    {
//      ILoggerFactory loggerFactory = new LoggerFactory();
//      ILogger<RegionController> _logger = new Logger<RegionController>(loggerFactory);
//      regionController = new RegionController(_logger);
//    }

//    [TestMethod()]
//    public void GetTest()
//    {
//      var regions = regionController.Get();

//      Assert.IsNotNull(regions);
//    }

//    [TestMethod()]
//    public void GetByIdTest()
//    {
//      string id = "EUR";
//      var region = regionController.Get(id);
//      Assert.AreEqual(id, region?.Id);
//    }
//  }
//}