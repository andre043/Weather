namespace WeatherAPI.Model
{
  public class DailyForecastsResult
  {
    public int Status { get; set; }
    public string Message { get; set; }
    public string Data { get; set; }
  }

  public class Headline
  {
    public string EffectiveDate { get; set; }
    public long EffectiveEpochDate { get; set; }
    public int Severity { get; set; }
    public string Text { get; set; }
    public string Category { get; set; }
    public string EndDate { get; set; }
    public long EndEpochDate { get; set; }
    public string MobileLink { get; set; }
    public string Link { get; set; }
  }

  public class Sun
  {
    public string Rise { get; set; }
    public long EpochRise { get; set; }
    public string Set { get; set; }
    public long EpochSet { get; set; }
  }

  public class Moon
  {
    public string Rise { get; set; }
    public long EpochRise { get; set; }
    public string Set { get; set; }
    public long EpochSet { get; set; }
    public string Phase { get; set; }
    public int Age { get; set; }
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

  public class DegreeDaySummary
  {
    public Heating Minimum { get; set; }
    public Cooling Maximum { get; set; }
  }

  public class Heating
  {
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
  }

  public class Cooling
  {
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
  }

  public class AirAndPollen
  {
    public string Name { get; set; }
    public int Value { get; set; }
    public string Category { get; set; }
    public int CategoryValue { get; set; }
    public string Type { get; set; }
  }

  public class LocalSource
  {
    public int id { get; set; }
    public string Name { get; set; }
    public string WeatherCode { get; set; }
  }
  public class Wind
  {
    public Direction Direction { get; set; }
    public Speed Speed { get; set; }
  }

  public class Direction
  {
    public int Degrees { get; set; }
    public string English { get; set; }
    public string Localized { get; set; }
  }
  public class Speed
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }
  public class WindGust
  {
    public Speed Speed { get; set; }
  }

  public class TotalLiquid
  {
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
  }
  public class Snow
  {
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
  }
  public class Rain
  {
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
  }
  public class Ice
  {
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
  }

  public class Evapotranspiration
  {
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
  }

  public class SolarIrradiance
  {
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
  }
  public class Day
  {
    public int Icon { get; set; }
    public string IconPhrase { get; set; }
    public LocalSource LocalSource { get; set; }
    public bool HasPrecipitation { get; set; }
    public string PrecipitationType { get; set; }
    public string PrecipitationIntensity { get; set; }
    public string ShortPhrase { get; set; }
    public string LongPhrase { get; set; }
    public int PrecipitationProbability { get; set; }
    public int ThunderstormProbability { get; set; }
    public int RainProbability { get; set; }
    public int SnowProbability { get; set; }
    public int IceProbability { get; set; }
    public Wind Wind { get; set; }
    public WindGust WindGust { get; set; }
    public TotalLiquid TotalLiquid { get; set; }
    public Rain Rain { get; set; }
    public Snow Snow { get; set; }
    public Ice Ice { get; set; }
    public float HoursOfPrecipitation { get; set; }
    public float HoursOfRain { get; set; }
    public int CloudCover { get; set; }
    public int Evapotranspiration { get; set; }
    public int SolarIrradiance { get; set; }
  }
  public class Night
  {
    public int Icon { get; set; }
    public string IconPhrase { get; set; }
    public LocalSource LocalSource { get; set; }
    public bool HasPrecipitation { get; set; }
    public string PrecipitationType { get; set; }
    public string PrecipitationIntensity { get; set; }
    public string ShortPhrase { get; set; }
    public string LongPhrase { get; set; }
    public int PrecipitationProbability { get; set; }
    public int ThunderstormProbability { get; set; }
    public int RainProbability { get; set; }
    public int SnowProbability { get; set; }
    public int IceProbability { get; set; }
    public Wind Wind { get; set; }
    public WindGust WindGust { get; set; }
    public TotalLiquid TotalLiquid { get; set; }
    public Rain Rain { get; set; }
    public Snow Snow { get; set; }
    public Ice Ice { get; set; }
    public float HoursOfPrecipitation { get; set; }
    public float HoursOfRain { get; set; }
    public int CloudCover { get; set; }
    public int Evapotranspiration { get; set; }
    public int SolarIrradiance { get; set; }
  }



  public class DailyForecasts
  {
    public string Date { get; set; }
    public long EpochDate { get; set; }
    public Sun Sun { get; set; }
    public Moon Moon { get; set; }
    public Temperature Temperature { get; set; }
    public RealFeelTemperature RealFeelTemperature { get; set; }
    public RealFeelTemperatureShade RealFeelTemperatureShade { get; set; }
    public float HoursOfSun { get; set; }
    public DegreeDaySummary DegreeDaySummary { get; set;}
    public AirAndPollen AirAndPollen { get; set; }
    public Day Day { get; set; }
    public Night Night { get; set; }
    public string Sources { get; set; }
    public string MobileLink { get; set; }
    public string Link { get; set; }
  }


  public class DailyForecastsList
  {
    public Headline Headline { get; set; }
    public DailyForecasts DailyForecasts { get; set; }

  }
}
