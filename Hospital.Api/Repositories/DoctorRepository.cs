using Hospital.Api.Dtos;
using Hospital.Api.Models;
using Hospital.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.Repositories
{
  public class DoctorRepository : IDoctorRepository
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

    public async Task<bool> UpdateAsync(Doctor entity)
    {
      var doctor = await GetByIdAsync(entity.DoctorId);

      doctor.Name = entity.Name;
      doctor.Specialization = entity.Specialization;
      doctor.Email = entity.Email;
      doctor.Password = entity.Password;

      return await _database.SaveAsync();
    }

    public async Task<bool> DeleteAsync(Doctor entity)
    {
      _database.Doctor.Remove(entity);
      return await _database.SaveAsync();
    }

    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
      return await _database.Doctor
        .Include(doctor => doctor.Appointments)
        .ThenInclude(appointment => appointment.Patient)
        .ToListAsync();
    }

    public async Task<Doctor?> GetByIdAsync(int doctorId)
    {
      return await _database.Doctor.FindAsync(doctorId);
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
      return await _database.Doctor.AnyAsync(doctor => doctor.Email.Equals(email));
    }
  }
}
