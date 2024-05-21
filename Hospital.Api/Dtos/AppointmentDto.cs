namespace Hospital.Api.Dtos
{
  public class AppointmentDto
  {
    public DateTime Date { get; set; }
    public string Surgery { get; set; }
    public string Diagnostic { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
  }
}
