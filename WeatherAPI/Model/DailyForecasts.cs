﻿namespace WeatherAPI.Model
{
    public class DailyForecastsResult
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
    }
    public class DailyForecastsRoot
    {
        public Headline Headline { get; set; }
        public List<DailyForecast> DailyForecasts { get; set; }
    }
    public class DailyForecast
    {
        public DateTime Date { get; set; }
        public int? EpochDate { get; set; }
        public Sun Sun { get; set; }
        public Moon Moon { get; set; }
        public Temperature Temperature { get; set; }
        public RealFeelTemperature RealFeelTemperature { get; set; }
        public RealFeelTemperatureShade RealFeelTemperatureShade { get; set; }
        public double HoursOfSun { get; set; }
        public DegreeDaySummary DegreeDaySummary { get; set; }
        public List<AirAndPollen> AirAndPollen { get; set; }
        public Day Day { get; set; }
        public Night Night { get; set; }
        public List<string> Sources { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }

    public class Day
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
        public bool HasPrecipitation { get; set; }
        public string ShortPhrase { get; set; }
        public string LongPhrase { get; set; }
        public int? PrecipitationProbability { get; set; }
        public int? ThunderstormProbability { get; set; }
        public int? RainProbability { get; set; }
        public int? SnowProbability { get; set; }
        public int? IceProbability { get; set; }
        public Wind Wind { get; set; }
        public WindGust WindGust { get; set; }
        public TotalLiquid TotalLiquid { get; set; }
        public Rain Rain { get; set; }
        public Snow Snow { get; set; }
        public Ice Ice { get; set; }
        public double HoursOfPrecipitation { get; set; }
        public double HoursOfRain { get; set; }
        public double HoursOfSnow { get; set; }
        public double HoursOfIce { get; set; }
        public int CloudCover { get; set; }
        public Evapotranspiration Evapotranspiration { get; set; }
        public SolarIrradiance SolarIrradiance { get; set; }
    }

    public class DegreeDaySummary
    {
        public Heating Heating { get; set; }
        public Cooling Cooling { get; set; }
    }
    public class Evapotranspiration
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Headline
    {
        public DateTime EffectiveDate { get; set; }
        public int? EffectiveEpochDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public DateTime? EndDate { get; set; }
        public int? EndEpochDate { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }

    public class Night
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
        public bool HasPrecipitation { get; set; }
        public string ShortPhrase { get; set; }
        public string LongPhrase { get; set; }
        public int PrecipitationProbability { get; set; }
        public int ThunderstormProbability { get; set; }
        public int RainProbability { get; set; }
        public int SnowProbability { get; set; }
        public int IceProbability { get; set; }
        public Wind? Wind { get; set; }
        public WindGust? WindGust { get; set; }
        public TotalLiquid TotalLiquid { get; set; }
        public Rain Rain { get; set; }
        public Snow Snow { get; set; }
        public Ice Ice { get; set; }
        public double HoursOfPrecipitation { get; set; }
        public double HoursOfRain { get; set; }
        public double HoursOfSnow { get; set; }
        public double HoursOfIce { get; set; }
        public int CloudCover { get; set; }
        public Evapotranspiration Evapotranspiration { get; set; }
        public SolarIrradiance SolarIrradiance { get; set; }
    }

    public class Rain
    {
        public double? Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }
    public class Snow
    {
        public double? Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class SolarIrradiance
    {
        public double? Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Speed
    {
        public double? Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }
    public class TotalLiquid
    {
        public double? Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }


    public class AirAndPollen
    {
        public string Name { get; set; }
        public int? Value { get; set; }
        public string Category { get; set; }
        public int CategoryValue { get; set; }
        public string? Type { get; set; }
    }
    public class Cooling
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Heating
    {
        public double? Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }
    public class Ice
    {
        public double? Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }
}
