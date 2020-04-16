﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RC.Recloti.Data.Context;

namespace RC.Recloti.Data.Migrations
{
    [DbContext(typeof(ReclotiContext))]
    partial class ReclotiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RC.Recloti.Domain.Entities.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION")
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.ToTable("PROFILE");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Cliente"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Moderador"
                        });
                });

            modelBuilder.Entity("RC.Recloti.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("ACTIVE")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .HasColumnName("ADDRESS")
                        .HasColumnType("varchar(80)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("BIRTH_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cellphone")
                        .HasColumnName("CELLPHONE")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("City")
                        .HasColumnName("CITY")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .HasColumnName("EMAIL")
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Gender")
                        .HasColumnName("GENDER")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Neighborhood")
                        .HasColumnName("NEIGHBORHOOD")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Number")
                        .HasColumnName("NUMBER")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnName("PASS")
                        .HasColumnType("varchar(120)");

                    b.Property<int?>("ProfileId")
                        .HasColumnName("ID_PROFILE")
                        .HasColumnType("int");

                    b.Property<string>("ProfilePhoto")
                        .HasColumnName("PROFILE_PHOTO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("REGISTER_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .HasColumnName("STATE")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("UPDATE_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZipCode")
                        .HasColumnName("ZIP_CODE")
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("USER");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            BirthDate = new DateTime(1111, 1, 1, 1, 11, 11, 111, DateTimeKind.Unspecified),
                            Email = "adm@adm.com.br",
                            Name = "Administrador",
                            Number = 0,
                            Password = "753eb493837bbbdc5e1ddc7bb182ae5924198d68",
                            ProfileId = 1,
                            RegisterDate = new DateTime(1111, 1, 1, 1, 11, 11, 111, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(1111, 1, 1, 1, 11, 11, 111, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("RC.Recloti.Domain.Entities.User", b =>
                {
                    b.HasOne("RC.Recloti.Domain.Entities.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId");
                });
#pragma warning restore 612, 618
        }
    }
}
