namespace DemoTask.Entity.Response
{
  public class Response
  {
    public object? Data { get; set; }
    public StatusCode StatusCode { get; set; }
    public string Message { get; set; }
  }
}
