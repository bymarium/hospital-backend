using System.Text.Json.Serialization;

namespace Hospital.Api.Dtos
{
  public class PatientDto
  {
    [JsonPropertyName("patientId")]
    public int PatientId { get; set; }

    [JsonPropertyName("roleId")]
    public int RoleId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("age")]
    public int Age { get; set; }

    [JsonPropertyName("rh")]
    public string Rh { get; set; }

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
