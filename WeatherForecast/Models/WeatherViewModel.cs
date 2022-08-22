using System;
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
    public string Link { get; set; }
    public List<Forcast> Forcast { get; set; }
  }

  public class Forcast
  {
    public DateTime Date { get; set; }
    public string ShortPhrase { get; set; }
    public Sun Sun { get; set; }
    public Moon Moon { get; set; }
    public Temperature Temperature { get; set; }
    public RealFeelTemperature RealFeelTemperature { get; set; }
  }

  public class Sun
  {
    public DateTime Rise { get; set; }
    public int EpochRise { get; set; }
    public DateTime Set { get; set; }
    public int EpochSet { get; set; }
  }

  public class Moon
  {
    public DateTime Rise { get; set; }
    public int EpochRise { get; set; }
    public DateTime Set { get; set; }
    public int EpochSet { get; set; }
    public string Phase { get; set; }
    public int Age { get; set; }
  }

  public class Minimum
  {
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
  }
  public class Maximum
  {
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
  }
  public class Temperature
  {
    public Minimum Minimum { get; set; }
    public Maximum Maximum { get; set; }
  }
  public class RealFeelTemperature
  {
    public Minimum Minimum { get; set; }
    public Maximum Maximum { get; set; }
  }
}
