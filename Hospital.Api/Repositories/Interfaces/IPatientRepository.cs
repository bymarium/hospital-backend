using Hospital.Api.Models;

namespace Hospital.Api.Repositories.Interfaces
{
  public interface IPatientRepository : IRepository<Patient>
  {
    Task<bool> EmailExistsAsync(string email);
  }
}
