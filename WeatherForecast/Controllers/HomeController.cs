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

    public ActionResult<ResultViewModel> GetCall(string city, string province, string country, DateTime date)
    {
      //var client = new RestClient("https://andrevoslooweatherapi.azurewebsites.net/api/CurrentAndDailyForcast/byCityProvinceCountry?city=" + city + "&province=" + province + "&country=" + country);
      var client = new RestClient("https://localhost:7108/api/CurrentAndDailyForcast/byCityProvinceCountry?city="+ city + "&province="+ province + "&country="+country);
      var response = client.Execute(new RestRequest());
      var result = JsonConvert.DeserializeObject<ResultViewModel>(response.Content);

      if (result is null)
      {
        throw new Exception("Failed To Get Results.");
      }
      else if (result.Forcast is null)
      {
        throw new Exception("Failed To Get Forcast.");
      }
      else 
      {
        result.Forcast = result.Forcast.Where(r => r.Date.Date == date.Date).ToList();
        return result;
      }
 
    }

  }
}
