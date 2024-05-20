namespace Hospital.Api.Models
{
  public class Patient : User
  {
    public int PatientId { get; set; }
    public int Age { get; set; }
    public string Rh {  get; set; }
    public IEnumerable<Appointment>? Appointments { get; set; }
  }
}
