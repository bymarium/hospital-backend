using Hospital.Api.Models;
using Hospital.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.Repositories
{
  public class DoctorRepository : IRepository<Doctor>
  {
    private readonly IDatabase _database;

    public DoctorRepository(IDatabase database)
    {
      _database = database;
    }
    public async Task<Doctor?> CreateAsync(Doctor entity)
    {
      _database.Doctor.Add(entity);

      if (!await _database.SaveAsync()) 
      {
        return null;
      }

      return await _database.Doctor.FirstOrDefaultAsync(doctor => doctor.DoctorId.Equals(entity.DoctorId));
    }

    public Task<bool> DeleteAsync(Doctor entity)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Doctor>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<Doctor?> GetByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Doctor entity)
    {
      throw new NotImplementedException();
    }
  }
}
