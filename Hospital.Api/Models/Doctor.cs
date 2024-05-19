namespace Hospital.Api.Models
{
  public class Doctor : User
  {
    public int DoctorId { get; set; }
    public string Specialization { get; set;}
  }
}
