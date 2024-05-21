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
      return await _database.Appointment.ToListAsync();
    }

    public async Task<Appointment?> GetByIdAsync(int appointmentId)
    {
      return await _database.Appointment.FindAsync(appointmentId);
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsByAgeAsync(int age)
    {
      DateTime forgetDate = CalculateForgetDate(age);

      return await _database.Appointment.Where(a => a.PatientId == null && a.Date >= forgetDate).ToListAsync();
    }

    private DateTime CalculateForgetDate(int age)
    {
      DateTime currentDate = DateTime.Now;

      if (age > 24 && age < 36)
      {
        return currentDate.AddMonths(2).AddDays(15);
      }
      else if (age > 35 && age < 46)
      {
        return currentDate.AddMonths(1).AddDays(15);
      }
      else if (age > 46)
      {
        return currentDate.AddDays(15);
      }
      else
      {
        return currentDate.AddMonths(3);
      }
    }
  }
}
