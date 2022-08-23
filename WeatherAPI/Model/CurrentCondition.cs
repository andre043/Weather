namespace WeatherAPI.Model
{
  public class CurrentConditionResult
  {
    public int StatusCode { get; set; }
    public object Message { get; set; }
    public string Data { get; set; }
  }

  public class CurrentCondition
  {
    public string LocalObservationDateTime { get; set; }
    public long EpochTime { get; set; }
    public string WeatherText { get; set; }
    public int? WeatherIcon { get; set; }
    public LocalSource LocalSource { get; set; }
    public bool IsDayTime { get; set; }
    public Temperature Temperature { get; set; }
    public RealFeelTemperature RealFeelTemperature { get; set; }
    public RealFeelTemperatureShade RealFeelTemperatureShade { get; set; }
    public int? RelativeHumidity { get; set; }
    public DewPoint DewPoint { get; set; }
    public Wind? Wind { get; set; }
    public int UVIndex { get; set; }
    public string UVIndexText { get; set; }
    public Visibility Visibility { get; set; }
    public string ObstructionsToVisibility { get; set; }
    public int CloudCover { get; set; }
    public Ceiling Ceiling { get; set; }
    public Pressure Pressure { get; set; }
    public PressureTendency PressureTendency { get; set; }
    public Past24HourTemperatureDeparture Past24HourTemperatureDeparture { get; set; }
    public ApparentTemperature ApparentTemperature { get; set; }
    public WindChillTemperature WindChillTemperature { get; set; }
    public WetBulbTemperature WetBulbTemperature { get; set; }
    public Precip1hr Precip1hr { get; set; }
    public PrecipitationSummary PrecipitationSummary { get; set; }
    public TemperatureSummary TemperatureSummary { get; set; }
    public string MobileLink { get; set; }
    public string Link { get; set; }
    public bool hasPrecipitation { get; set; }
    public string PrecipitationType { get; set; }
    public bool IndoorRelativeHumidity { get; set; }
  }

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
  public class DewPoint
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }
  public class Visibility
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }

  public class Ceiling
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }

  public class Pressure
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }

  public class PressureTendency
  {
    public string LocalizedText { get; set; }
    public string Code { get; set; }
  }
  public class Past24HourTemperatureDeparture
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }



  public class ApparentTemperature
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }
  public class WindChillTemperature
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }
  public class WetBulbTemperature
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }
  public class Precip1hr
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }

  public class PrecipitationSummary
  {
    public Precipitation? Precipitation { get; set; }
    public PastHour PastHour { get; set; }
    public Past3Hours Past3Hours { get; set; }
    public Past6Hours Past6Hours { get; set; }
    public Past9Hours Past9Hours { get; set; }
    public Past12Hour Past12Hour { get; set; }
    public Past18Hour Past18Hour { get; set; }
    public Past24Hours Past24Hours { get; set; }
  }


  public class Precipitation
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }

  public class PastHour
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }
  public class Past3Hours
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }
  public class Past6Hours
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }
  public class Past9Hours
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }
  public class Past12Hour
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }
  public class Past18Hour
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }
  public class Past24Hours
  {
    public Metric Metric { get; set; }
    public Imperial Imperial { get; set; }
  }

  public class TemperatureSummary
  {
    public Past6HourRange Past6HourRange { get; set; }
    public Past12HourRange Past12HourRange { get; set; }
    public Past24HourRange Past24HourRange { get; set; }
  }

  public class Past6HourRange
  {
    public Minimum Minimum { get; set; }
    public Maximum Maximum { get; set; }
  }

  public class Past12HourRange
  {
    public Minimum Minimum { get; set; }
    public Maximum Maximum { get; set; }
  }
  public class Past24HourRange
  {
    public Minimum Minimum { get; set; }
    public Maximum Maximum { get; set; }
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

  public class RealFeelTemperatureShade
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
