using Hospital.Api.Dtos;
using Hospital.Api.Models;

namespace Hospital.Api.Services.Interfaces
{
  public interface IDoctorService : IService<Doctor>
  {
    Task<Doctor> CreateAsync(DoctorDto entity);

  }
}
