using Hospital.Api.Dtos;
using Hospital.Api.Models;
using Hospital.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.Repositories
{
  public class AppointmentRepository : IAppointmentRepository
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

    public async Task<bool> DeleteAsync(Appointment entity)
    {
      _database.Appointment.Remove(entity);
      return await _database.SaveAsync();
    }

    public async Task<IEnumerable<Appointment>> GetAllAsync()
    {
      var appointments = await _database.Appointment
             .Include(appointment => appointment.Patient)
             .Include(appointment => appointment.Doctor)
             .ToListAsync();

      return appointments;
    }

    public async Task<Appointment?> GetByIdAsync(int appointmentId)
    {
       return await _database.Appointment.FindAsync(appointmentId);
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsByAgeAsync(DateTime forgetDate)
    {
      return await _database.Appointment
        .Include(a => a.Patient)
        .Include(a => a.Doctor)
        .Where(a => a.PatientId == null && a.Date >= forgetDate)
        .ToListAsync();
    }
  }
}

