using Hospital.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Api.Repositories.Config.Tables
{
  public class PatientConfiguration
  {
    public PatientConfiguration(EntityTypeBuilder<Patient> entityBuilder)
    {
      entityBuilder.HasKey(patient => patient.PatientId);
      entityBuilder.Property(patient => patient.RoleId).IsRequired();
      entityBuilder.Property(patient => patient.Name).IsRequired();
      entityBuilder.Property(patient => patient.Age).IsRequired();
      entityBuilder.Property(patient => patient.Rh).IsRequired();
      entityBuilder.Property(patient => patient.Email).IsRequired();
      entityBuilder.Property(patient => patient.Password).IsRequired();

      entityBuilder
        .HasOne(patient => patient.Role)
        .WithMany(role => role.Patients)
        .HasForeignKey(patient => patient.RoleId);

      entityBuilder
        .HasMany(patient => patient.Appointments)
        .WithOne(appointment => appointment.Patient)
        .HasForeignKey(appointment => appointment.PatientId);
    }
  }
}
