using Hospital.Api.Dtos;
using Hospital.Api.Models;

namespace Hospital.Api.Services.Interfaces
{
  public interface IAppointmentService : IService<Appointment>
  {
    Task<Appointment> CreateAsync(AppointmentDto entity);

  }
}
