using Hospital.Api.Models;

namespace Hospital.Api.Repositories.Interfaces
{
  public interface IAppointmentRepository : IRepository<Appointment>
  {
    public Task<IEnumerable<Appointment>> GetAppointmentsByAgeAsync(int age);
  }
}
