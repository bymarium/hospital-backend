using System.Text.Json.Serialization;

namespace Hospital.Api.Dtos
{
  public class ErrorDto
  {
    [JsonPropertyName("message")]
    public string Message { get; set; }

    public ErrorDto(string Message)
    {
      this.Message = Message;
    }
  }
}
