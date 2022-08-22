using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WeatherForecast.Models;
 

namespace WeatherForecast.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult<ResultViewModel> GetCall(string city, string province, string country)
    {
      var client = new RestClient("https://localhost:7108/api/CurrentAndDailyForcast/byCity?cityName="+city);
      var response = client.Execute(new RestRequest());
      var result = JsonConvert.DeserializeObject<ResultViewModel>(response.Content);
      return result; 
    }

  }
}
