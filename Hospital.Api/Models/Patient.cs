namespace Hospital.Api.Models
{
  public class Patient
  {
    public int PatientId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Rh {  get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IEnumerable<Appointment>? Appointments { get; set; }
  }
}
