using Hospital.Api.Models;
using Hospital.Api.Repositories.Config.Tables;
using Hospital.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.Repositories.Config
{
  public class Database : DbContext, IDatabase
  {
    public DbSet<Patient> Patient { get; set; }
    public DbSet<Doctor> Doctor { get; set; }
    public DbSet<Appointment> Appointment { get; set; }

    public Database(DbContextOptions options) : base(options) { }

    public async Task<bool> SaveAsync ()
    {
      return await SaveChangesAsync() > 0;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      EntityConfiguration(modelBuilder);
    }

    private void EntityConfiguration(ModelBuilder modelBuilder)
    {
      new PatientConfiguration(modelBuilder.Entity<Patient>());
      new DoctorConfiguration(modelBuilder.Entity<Doctor>());
      new AppointmentConfiguration(modelBuilder.Entity<Appointment>());
    }
  }
}
