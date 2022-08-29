namespace WeatherAPI.Model
{
  public class Metric
  {
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
  }
  public class Imperial
  {
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
  }
  public class Moon
  {
    public DateTime? Rise { get; set; }
    public int? EpochRise { get; set; }
    public DateTime? Set { get; set; }
    public int? EpochSet { get; set; }
    public string Phase { get; set; }
    public int Age { get; set; }
  }
  public class Sun
  {
    public DateTime? Rise { get; set; }
    public int? EpochRise { get; set; }
    public DateTime? Set { get; set; }
    public int? EpochSet { get; set; }
  }
  public class Direction
  {
    public int Degrees { get; set; }
    public string Localized { get; set; }
    public string English { get; set; }
  }
  public class Wind
  {
    public Speed Speed { get; set; }
    public Direction Direction { get; set; }
  }

  public class WindGust
  {
    public Speed Speed { get; set; }
    public Direction Direction { get; set; }
  }
  public class LocalSource
  {
    public int id { get; set; }
    public string Name { get; set; }
    public string WeatherCode { get; set; }
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
  public class RealFeelTemperatureShade
  {
    public Minimum Minimum { get; set; }
    public Maximum Maximum { get; set; }
  }
  public class Minimum
  {
    public double? Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
    public string? Phrase { get; set; }
  }
  public class Maximum
  {
    public double? Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
    public string? Phrase { get; set; }
  }
}
