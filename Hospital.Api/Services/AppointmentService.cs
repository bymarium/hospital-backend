using Hospital.Api.Models;
using Hospital.Api.Repositories.Interfaces;
using Hospital.Api.Services.Interfaces;

namespace Hospital.Api.Services
{
  public class AppointmentService : IService<Appointment>
  {
    private readonly IRepository<Appointment> _repository;

    public AppointmentService(IRepository<Appointment> repository)
    {
      _repository = repository;
    }

    public async Task<Appointment> CreateAsync(Appointment entity)
    {
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

    public Task<IEnumerable<Appointment>> GetAllAsync()
    {
      throw new NotImplementedException();
    }
  }
}
