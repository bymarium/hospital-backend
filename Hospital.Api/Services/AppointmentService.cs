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

    public Task<Appointment> DeleteAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Appointment>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<Appointment> UpdateAsync(Appointment entity)
    {
      throw new NotImplementedException();
    }
  }
}
