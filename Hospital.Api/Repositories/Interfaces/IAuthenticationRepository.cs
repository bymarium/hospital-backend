using Hospital.Api.Models;

namespace Hospital.Api.Repositories.Interfaces
{
  public interface IAuthenticationRepository
  {
    Task<Administrator?> validateAdminAsync(string email, string password);
    Task<Patient?> validatePatientAsync(string email, string password);
    Task<Doctor?> validateDoctorAsync(string email, string password);

  }
}
