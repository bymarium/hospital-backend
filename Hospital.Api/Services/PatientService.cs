using Hospital.Api.Dtos;
using Hospital.Api.Models;
using Hospital.Api.Repositories.Interfaces;
using Hospital.Api.Services.Interfaces;

namespace Hospital.Api.Services
{
  public class PatientService : IPatientService
  {
    private readonly IRepository<Patient> _repository;

    public PatientService(IRepository<Patient> repository)
    {
      _repository = repository;
    }

    public async Task<Patient> CreateAsync(PatientDto patientDto)
    {
      var entity = new Patient
      {
        Name = patientDto.Name,
        Age = patientDto.Age,
        Rh = patientDto.Rh,
        Email = patientDto.Email,
        Password = patientDto.Password,
        RoleId = patientDto.RoleId
      };

      var patient = await _repository.CreateAsync(entity);

      if (patient == null)
      {
        throw new Exception("Patient not created");
      }

      return patient;
    }
    public async Task<Patient> UpdateAsync(Patient entity)
    {
      var patient = await _repository.GetByIdAsync(entity.PatientId);

      if (patient == null)
      {
        throw new Exception("Patient not found");
      }

      if(!await _repository.UpdateAsync(entity))
      {
        throw new Exception("Patient not update");
      }

      return entity;
    }

    public async Task<Patient> DeleteAsync(int patientId)
    {
      var patient = await _repository.GetByIdAsync(patientId);

      if (patient == null)
      {
        throw new Exception("Patient not found");
      }

      if (!await _repository.DeleteAsync(patient))
      {
        throw new Exception("Patient not delete");
      }

      return patient;
    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
    {
      return await _repository.GetAllAsync();
    }
  }
}
