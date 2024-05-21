using Hospital.Api.Dtos;
using Hospital.Api.Models;

namespace Hospital.Api.Services.Interfaces
{
  public interface IPatientService : IService<Patient>
  {
    Task<Patient> CreateAsync(PatientDto entity);
  }
}
