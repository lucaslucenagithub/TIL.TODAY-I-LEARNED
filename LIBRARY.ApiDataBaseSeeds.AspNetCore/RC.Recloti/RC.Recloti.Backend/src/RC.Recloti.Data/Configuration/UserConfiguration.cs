using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RC.Recloti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RC.Recloti.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.ToTable("USER");

            modelBuilder
                .Property(a => a.Id)
                .HasColumnName("ID");

            modelBuilder
                .Property("ProfileId")
                .HasColumnName("ID_PROFILE");

            modelBuilder
                .Property(a => a.Name)
                .HasColumnType("varchar(80)")
                .HasColumnName("NAME");

            modelBuilder
               .Property(a => a.Email)
               .HasColumnType("varchar(80)")
               .HasColumnName("EMAIL");

            modelBuilder
               .Property(a => a.Password)
               .HasColumnType("varchar(120)")
               .HasColumnName("PASS");

            modelBuilder
              .Property(a => a.Gender)
              .HasColumnType("varchar(25)")
              .HasColumnName("GENDER");

            modelBuilder
              .Property(a => a.BirthDate)
              .HasColumnName("BIRTH_DATE");

            modelBuilder
              .Property(a => a.ZipCode)
              .HasColumnType("varchar(25)")
              .HasColumnName("ZIP_CODE");

            modelBuilder
              .Property(a => a.State)
              .HasColumnType("varchar(50)")
              .HasColumnName("STATE");

            modelBuilder
              .Property(a => a.City)
              .HasColumnType("varchar(50)")
              .HasColumnName("CITY");

            modelBuilder
              .Property(a => a.Neighborhood)
              .HasColumnType("varchar(50)")
              .HasColumnName("NEIGHBORHOOD");

            modelBuilder
              .Property(a => a.Address)
              .HasColumnType("varchar(80)")
              .HasColumnName("ADDRESS");

            modelBuilder
              .Property(a => a.Number)
              .HasColumnName("NUMBER");

            modelBuilder
              .Property(a => a.Cellphone)
              .HasColumnType("varchar(25)")
              .HasColumnName("CELLPHONE");

            modelBuilder
              .Property(a => a.ProfilePhoto)
              .HasColumnName("PROFILE_PHOTO");

            modelBuilder
              .Property(a => a.Active)
              .HasColumnName("ACTIVE");

            modelBuilder
              .Property(a => a.RegisterDate)
              .HasColumnName("REGISTER_DATE");

            modelBuilder
              .Property(a => a.UpdateDate)
              .HasColumnName("UPDATE_DATE");

        }
    }
}
