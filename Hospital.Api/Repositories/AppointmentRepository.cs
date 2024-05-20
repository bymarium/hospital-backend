using Hospital.Api.Models;
using Hospital.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.Repositories
{
  public class AppointmentRepository : IRepository<Appointment>
  {
    private readonly IDatabase _database;

    public AppointmentRepository(IDatabase database)
    {
      _database = database;
    }

    public async Task<Appointment?> CreateAsync(Appointment entity)
    {
      _database.Appointment.Add(entity);

      if (!await _database.SaveAsync())
      {
        return null;
      }

      return await _database.Appointment.FirstOrDefaultAsync(appointment => appointment.AppointmentId.Equals(entity.AppointmentId));
    }

    public async Task<bool> UpdateAsync(Appointment entity)
    {
      var appointment = await GetByIdAsync(entity.AppointmentId);

      appointment.PatientId = entity.PatientId;
      appointment.DoctorId = entity.DoctorId;
      appointment.Date = entity.Date;
      appointment.Surgery = entity.Surgery;
      appointment.Diagnostic = entity.Diagnostic;

      return await _database.SaveAsync();
    }

    public Task<bool> DeleteAsync(Appointment entity)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Appointment>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<Appointment?> GetByIdAsync(int id)
    {
      throw new NotImplementedException();
    }
  }
}
