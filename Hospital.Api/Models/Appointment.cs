namespace Hospital.Api.Models
{
  public class Appointment
  {
    public int AppointmentId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime Date { get; set; }
    public string Surgery { get; set; }
    public string Diagnostic { get; set; }
    public Patient? Patient { get; set; }
    public Doctor? Doctor { get; set; }
  }
}
