using System.Text.Json.Serialization;

namespace Hospital.Api.Dtos
{
  public class DoctorDto
  {
    [JsonPropertyName("doctorId")]
    public int DoctorId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("specialization")]
    public string Specialization { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("appointments")]
    public IEnumerable<AppointmentDto>? Appointments { get; set; }

  }
}
