using Hospital.Api.Models;
using Hospital.Api.Repositories.Interfaces;
using Hospital.Api.Services.Interfaces;
using System.Linq.Expressions;

namespace Hospital.Api.Services
{
  public class DoctorService : IService<Doctor>
  {
    private readonly IRepository<Doctor> _repository;

    public DoctorService(IRepository<Doctor> repository)
    {
      _repository = repository;
    }

    public async Task<Doctor> CreateAsync(Doctor entity)
    {
      var doctor = await _repository.CreateAsync(entity);

      if (doctor == null)
      {
        throw new Exception("Patient not found");
      }

      return doctor;
    }

    public Task<Doctor> DeleteAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Doctor>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<Doctor> UpdateAsync(Doctor entity)
    {
      throw new NotImplementedException();
    }
  }
}
