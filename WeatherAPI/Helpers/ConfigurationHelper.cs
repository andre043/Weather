namespace WeatherAPI.Helpers
{
  static class JsonConfigurationManager
  {
    public static IConfiguration AppSetting { get; }
    static JsonConfigurationManager()
    {
      AppSetting = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();
    }
  }

}
