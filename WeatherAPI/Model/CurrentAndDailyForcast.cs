namespace WeatherAPI.Model
{
  public class CurrentAndDailyForcast
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

}
