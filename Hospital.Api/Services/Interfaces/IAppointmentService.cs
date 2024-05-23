using Hospital.Api.Dtos;
using Hospital.Api.Models;

namespace Hospital.Api.Services.Interfaces
{
  public interface IAppointmentService : IService<AppointmentDto>
  {
    public Task<IEnumerable<AppointmentDto>> GetAppointmentsByAgeAsync(int age);
  }
}
