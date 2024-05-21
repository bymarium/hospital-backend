using Hospital.Api.Dtos;
using Hospital.Api.Models;
using Hospital.Api.Repositories.Interfaces;
using Hospital.Api.Services.Interfaces;

namespace Hospital.Api.Services
{
  public class AppointmentService : IAppointmentService
  {
    private readonly IRepository<Appointment> _repository;

    public AppointmentService(IRepository<Appointment> repository)
    {
      _repository = repository;
    }

    public async Task<Appointment> CreateAsync(AppointmentDto appointmentDto)
    {
      var entity = new Appointment
      {
        Date = appointmentDto.Date,
        Surgery = appointmentDto.Surgery,
        Diagnostic = appointmentDto.Diagnostic,
        PatientId = appointmentDto.PatientId,
        DoctorId = appointmentDto.DoctorId
      };

      var appointment = await _repository.CreateAsync(entity);

      if(appointment == null)
      {
        throw new Exception("Appointment not created");
      }

      return appointment;
    }
    public async Task<Appointment> UpdateAsync(Appointment entity)
    {
      var appointement = await _repository.GetByIdAsync(entity.AppointmentId);

      if(appointement == null) 
      {
        throw new Exception("Appointment not found");
      }

      if (!await _repository.UpdateAsync(entity))
      {
        throw new Exception("Appointment not update");
      }

      return entity;
    }

    public async Task<Appointment> DeleteAsync(int appointmentId)
    {
      var appointement = await _repository.GetByIdAsync(appointmentId);

      if (appointement == null)
      {
        throw new Exception("Appointment not found");
      }

      if (!await _repository.DeleteAsync(appointement))
      {
        throw new Exception("Appointment not delete");
      }

      return appointement;
    }

    public async Task<IEnumerable<Appointment>> GetAllAsync()
    {
      return await _repository.GetAllAsync();
    }
  }
}
