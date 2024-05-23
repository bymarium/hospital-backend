using System.Text.Json.Serialization;

namespace Hospital.Api.Dtos
{
  public class AppointmentDto
  {
    [JsonPropertyName("appointmentId")]
    public int AppointmentId { get; set; }

    [JsonIgnore]
    public int? PatientId { get; set; }

    [JsonIgnore]
    public int DoctorId { get; set; }

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("surgery")]
    public string Surgery { get; set; }

    [JsonPropertyName("diagnostic")]
    public string Diagnostic { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("patient")]
    public PatientDto? Patient { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("doctor")]
    public DoctorDto? Doctor { get; set; }
  }
}
