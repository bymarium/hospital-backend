using Hospital.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.Repositories.Interfaces
{
  public interface IDatabase
  {
    public DbSet<Administrator> Administrator { get; }
    public DbSet<Patient> Patient { get; }
    public DbSet<Doctor> Doctor { get; }
    public DbSet<Appointment> Appointment { get; }

    Task<bool> SaveAsync();
  }
}
