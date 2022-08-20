namespace WeatherAPI.Model
{
  public class Cities
  {
    public int Version { get; set; }
    public string Key { get; set; }
    public string Type { get; set; }
    public int Rank { get; set; }
    public string LocalizedName { get; set; }
    public Country Country { get; set; }
    public AdministrativeArea AdministrativeArea { get; set; }
  }

  public class Country
  {
    public string ID { get; set; }
    public string LocalizedName { get; set; }
  }

  public class AdministrativeArea
  {
    public string ID { get; set; }
    public string LocalizedName { get; set; }
  }

  public class CitiesResult
  {
    public int Status { get; set; }

    public string Message { get; set; }

    public string Data { get; set; }
  }
}
