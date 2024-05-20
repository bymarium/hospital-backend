using Hospital.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Api.Repositories.Config.Tables
{
  public class PatientConfiguration
  {
    public PatientConfiguration(EntityTypeBuilder<Patient> entityBuilder)
    {
      entityBuilder.HasKey(patient => patient.PatientId);
      entityBuilder.Property(patient => patient.Age).IsRequired();
      entityBuilder.Property(patient => patient.Rh).IsRequired();
    }
  }
}
