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
    public bool HasPrecipitation { get; set; }
    public string PrecipitationType { get; set; }
    public LocalSource LocalSource { get; set; }
    public bool IsDayTime { get; set; }
    public CurrentTemperature Temperature { get; set; }
    public CurrentRealFeelTemperature RealFeelTemperature { get; set; }
    public CurrentRealFeelTemperatureShade RealFeelTemperatureShade { get; set; }
    public int? RelativeHumidity { get; set; }
    public bool IndoorRelativeHumidity { get; set; }
    public DewPoint DewPoint { get; set; }
    public CurrentWind? Wind { get; set; }
    public CurrentWindGust? WindGust { get; set; }
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
  }

  public class DewPoint
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }
  public class Visibility
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }

  public class Ceiling
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }

  public class Pressure
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }

  public class PressureTendency
  {
    public string LocalizedText { get; set; }
    public string Code { get; set; }
  }
  public class Past24HourTemperatureDeparture
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }
  public class ApparentTemperature
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }
  public class WindChillTemperature
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }
  public class WetBulbTemperature
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }
  public class Precip1hr
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }

  public class PrecipitationSummary
  {
    public Precipitation? Precipitation { get; set; }
    public PastHour PastHour { get; set; }
    public Past3Hours Past3Hours { get; set; }
    public Past6Hours Past6Hours { get; set; }
    public Past9Hours Past9Hours { get; set; }
    public Past12Hours Past12Hours { get; set; }
    public Past18Hours Past18Hours { get; set; }
    public Past24Hours Past24Hours { get; set; }
  }



  public class Precipitation
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }

  public class PastHour
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }
  public class Past3Hours
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }
  public class Past6Hours
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }
  public class Past9Hours
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }
  public class Past12Hours
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }
  public class Past18Hours
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }
  public class Past24Hours
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }

  public class TemperatureSummary
  {
    public Past6HourRange Past6HourRange { get; set; }
    public Past12HourRange Past12HourRange { get; set; }
    public Past24HourRange Past24HourRange { get; set; }
  }

  public class Past6HourRange
  {
    public CurrentMaximum Maximum { get; set; }
    public CurrentMinimum Minimum { get; set; }
  }

  public class Past12HourRange
  {
    public CurrentMaximum Maximum { get; set; }
    public CurrentMinimum Minimum { get; set; }
  }
  public class Past24HourRange
  {
    public CurrentMaximum Maximum { get; set; }
    public CurrentMinimum Minimum { get; set; }
  }
  public class CurrentMinimum
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }
  public class CurrentMaximum
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }
  public class CurrentRealFeelTemperatureShade
  {
    public Metric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }

  public class CurrentTemperature
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }
  public class CurrentRealFeelTemperature
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }
  public class CurrentMetric
  {
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
    public string? Phrase { get; set; }
  }
  public class CurrentImperial
  {
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
    public string? Phrase { get; set; }
  }

  public class CurrentWind
  {
    public CurrentSpeed Speed { get; set; }
    public Direction Direction { get; set; }
  }

  public class CurrentWindGust
  {
    public CurrentSpeed Speed { get; set; }
    public Direction Direction { get; set; }
  }

  public class CurrentSpeed
  {
    public CurrentMetric Metric { get; set; }
    public CurrentImperial Imperial { get; set; }
  }
}