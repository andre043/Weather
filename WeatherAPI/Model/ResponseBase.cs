using System.Net;

namespace WeatherAPI.Model
{
  public class ResponseBase
  {
    public HttpStatusCode HttpStatusCode { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
  }
}
