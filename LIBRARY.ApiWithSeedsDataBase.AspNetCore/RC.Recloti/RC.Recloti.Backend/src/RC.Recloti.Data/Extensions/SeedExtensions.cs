using Microsoft.EntityFrameworkCore;
using RC.Recloti.Data.Context;
using RC.Recloti.Domain.Entities;
using RC.Recloti.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace RC.Recloti.Data.Extensions
{
    public static class SeedExtensions
    {

        public static void AdmUserSeed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
                new
                { 
                    ProfileId = 1,
                    Id = 1,
                    Name = "Administrador",
                    Email = "adm@adm.com.br",
                    Password = "753eb493837bbbdc5e1ddc7bb182ae5924198d68",
                    Active = true,
                    BirthDate = new DateTime(1111, 1, 1, 1, 11, 11, 111),
                    Number = 0,
                    RegisterDate = new DateTime(1111, 1, 1, 1, 11, 11, 111),
                    UpdateDate = new DateTime(1111, 1, 1, 1, 11, 11, 111)

                });
        }

        public static string GetEnumDescription<TEnum>(this TEnum item)
        => item.GetType()
              .GetField(item.ToString())
              .GetCustomAttributes(typeof(DescriptionAttribute), false)
              .Cast<DescriptionAttribute>()
              .FirstOrDefault()?.Description ?? string.Empty;


        public static void SeedEnumValues<T, TEnum>(this ModelBuilder mb, Func<TEnum, T> converter)
        where T : class => Enum.GetValues(typeof(TEnum))
                               .Cast<object>()
                               .Select(value => converter((TEnum)value))
                               .ToList()
                               .ForEach(instance => mb.Entity<T>().HasData(instance));
    }
}
