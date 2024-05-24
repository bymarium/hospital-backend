using Hospital.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Api.Repositories.Config.Tables
{
  public class AdministratorConfiguration
  {
    public AdministratorConfiguration(EntityTypeBuilder<Administrator> entityBuilder)
    {
      entityBuilder.HasKey(administrator => administrator.AdministratorId);
      entityBuilder.Property(administrator => administrator.Name).IsRequired();
      entityBuilder.Property(administrator => administrator.Email).IsRequired();
      entityBuilder.Property(administrator => administrator.Password).IsRequired();

    }
  }
}
