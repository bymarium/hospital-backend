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
    }
  }
}
