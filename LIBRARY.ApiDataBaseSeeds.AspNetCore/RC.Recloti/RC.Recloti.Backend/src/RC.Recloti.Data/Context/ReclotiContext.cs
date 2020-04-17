using Microsoft.EntityFrameworkCore;
using RC.Recloti.Data.Configuration;
using RC.Recloti.Data.Extensions;
using RC.Recloti.Domain.Entities;
using RC.Recloti.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RC.Recloti.Data.Context
{
    public class ReclotiContext : DbContext
    {

        public ReclotiContext()
        {

        }

        public ReclotiContext(DbContextOptions<ReclotiContext> options) : base(options)
        {

        }

        #region DbSet
        public DbSet<User> User { get; set; }
        public DbSet<Profile> Profile { get; set; }
        #endregion

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());

            ////Seeds:
            //try
            //{
            modelBuilder.SeedEnumValues<Profile, ProfileEnum>(e => e);
            modelBuilder.AdmUserSeed();
            //}
            //catch (Exception ex)
            //{

            //    //Logger in case someone create manually register in db, etc
            //}

            base.OnModelCreating(modelBuilder);
        }
    }
}
