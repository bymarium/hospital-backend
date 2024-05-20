using Hospital.Api.Models;
using Hospital.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.Repositories
{
  public class PatientRepository : IRepository<Patient>
  {
    private readonly IDatabase _database;

    public PatientRepository(IDatabase database)
    {
      _database = database;
    }

    public async Task<Patient?> CreateAsync(Patient entity)
    {
      _database.Patient.Add(entity);

      if (!await _database.SaveAsync())
      {
        return null;
      }

      return await _database.Patient.FirstOrDefaultAsync(patient => patient.PatientId.Equals(entity.PatientId));
    }

    public async Task<bool> UpdateAsync(Patient entity)
    {
      throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Patient entity)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Patient>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<Patient?> GetByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

   
  }
}
