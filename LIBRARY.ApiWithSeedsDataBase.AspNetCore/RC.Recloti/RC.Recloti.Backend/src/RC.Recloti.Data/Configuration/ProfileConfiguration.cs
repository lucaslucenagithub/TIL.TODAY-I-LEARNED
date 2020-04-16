using Microsoft.EntityFrameworkCore;
using RC.Recloti.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RC.Recloti.Data.Configuration
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> modelBuilder)
        {
            modelBuilder.ToTable("PROFILE");

            modelBuilder
                .Property(a => a.Id)
                .HasColumnName("ID");

            modelBuilder
                .Property(a => a.Description)
                .HasColumnType("varchar(25)")
                .HasColumnName("DESCRIPTION");

        }
    }
}
