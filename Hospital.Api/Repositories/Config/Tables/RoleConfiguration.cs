using Hospital.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Api.Repositories.Config.Tables
{
  public class RoleConfiguration
  {
    public RoleConfiguration(EntityTypeBuilder<Role> entityBuilder)
    {
      entityBuilder.HasKey(role => role.RoleId);
      entityBuilder.Property(role => role.Name).IsRequired();

      entityBuilder
        .HasMany(role => role.Patients)
        .WithOne(patient => patient.Role)
        .HasForeignKey(patient => patient.RoleId);

      entityBuilder
        .HasMany(role => role.Doctors)
        .WithOne(doctor => doctor.Role)
        .HasForeignKey(doctor => doctor.RoleId);
    }
  }
}
