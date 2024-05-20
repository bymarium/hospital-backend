﻿using Hospital.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Api.Repositories.Config.Tables
{
  public class UserConfiguration
  {
    public UserConfiguration(EntityTypeBuilder<User> entityBuilder)
    {
      entityBuilder.HasKey(user => user.UserId);
      entityBuilder.Property(user => user.RoleId).IsRequired();
      entityBuilder.Property(user => user.Name).IsRequired();
      entityBuilder.Property(user => user.Email).IsRequired();
      entityBuilder.Property(user => user.Password).IsRequired();

      entityBuilder
        .HasDiscriminator<string>("UserType")
        .HasValue<User>("User")
        .HasValue<Patient>("Patient")
        .HasValue<Doctor>("Doctor");
    }
  }
}
