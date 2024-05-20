using Hospital.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Api.Repositories.Config.Tables
{
  public class DoctorConfiguration
  {
    public DoctorConfiguration(EntityTypeBuilder<Doctor> entityBuilder)
    {
      entityBuilder.HasKey(doctor => doctor.DoctorId);
      entityBuilder.Property(doctor => doctor.Specialization).IsRequired();
    }
  }
}
