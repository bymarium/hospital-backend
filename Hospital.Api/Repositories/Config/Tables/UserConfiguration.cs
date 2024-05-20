using Hospital.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Api.Repositories.Config.Tables
{
  public class UserConfiguration
  {
    public UserConfiguration(EntityTypeBuilder<User> entityBuilder)
    {
      entityBuilder.HasKey(user => user.UserId);
      entityBuilder.Property(user => user.Name);
      entityBuilder.Property(user => user.Email);
      entityBuilder.Property(user => user.Password);
    }
  }
}
