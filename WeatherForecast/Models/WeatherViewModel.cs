﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast.Models
{
  public class ResultViewModel
  {
    public string Key { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string Country { get; set; }
  }
}
