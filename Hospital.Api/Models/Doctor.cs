namespace Hospital.Api.Models
{
  public class Doctor
  {
    public int DoctorId { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set;}
    public string Email { get; set; }
    public string Password { get; set; }
    public IEnumerable<Appointment>? Appointments { get; set; }
  }
}
