using Hospital.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Api.Repositories.Config.Tables
{
  public class AppointmentConfiguration
  {
    public AppointmentConfiguration(EntityTypeBuilder<Appointment> entityBuilder)
    {
      entityBuilder.HasKey(appointment => appointment.AppointmentId);
      entityBuilder.Property(appointment => appointment.Date).IsRequired();
      entityBuilder.Property(appointment => appointment.Surgery).IsRequired();
      entityBuilder.Property(appointment => appointment.Diagnostic).IsRequired();
    }
  }
}
