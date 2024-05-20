using Hospital.Api.Models;
using Hospital.Api.Repositories.Interfaces;
using Hospital.Api.Services.Interfaces;

namespace Hospital.Api.Services
{
  public class PatientService : IService<Patient>
  {
    private readonly IRepository<Patient> _repository;

    public PatientService(IRepository<Patient> repository)
    {
      _repository = repository;
    }

    public async Task<Patient> CreateAsync(Patient entity)
    {
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
        throw new Exception("User not update");
      }

      return entity;
    }

    public Task<Patient> DeleteAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Patient>> GetAllAsync()
    {
      throw new NotImplementedException();
    }
  }
}
