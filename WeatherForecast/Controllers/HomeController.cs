using Microsoft.AspNetCore.Mvc;
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

    public ActionResult<String> GetCall(string city, string province)
    {
      var client = new RestClient("https://andrevoslooweatherapi.azurewebsites.net/CurrentConditions/byCityProvince?city="+ city + "&province="+ province);
      var response = client.Execute(new RestRequest());
      return response.Content;
    }

  }
}
