using Hospital.Api.Models;

namespace Hospital.Api.Repositories.Interfaces
{
  public interface IDoctorRepository : IRepository<Doctor>
  {
    Task<bool> EmailExistsAsync(string email);
  }
}
