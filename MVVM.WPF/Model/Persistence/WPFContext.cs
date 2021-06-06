using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM.WPF.Model.Persistence
{
    class WPFContext : DbContext
    {
        public WPFContext() 
            : base()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookContext, EFDemo.Migrations.Configuration>());
            Database.EnsureCreated();
        }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder buildOptions)
        {            
            buildOptions.UseSqlite("Data Source=LocalDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
