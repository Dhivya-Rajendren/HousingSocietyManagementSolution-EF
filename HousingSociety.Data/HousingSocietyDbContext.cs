using HousingSociety.Domain;
using Microsoft.EntityFrameworkCore;

namespace HousingSociety.Data
{

    //DbContext class is used by EF Core to interact with database, for change tracking.
    public class HousingSocietyDbContext:DbContext
    {

        //DbSets are meant for represnting the entites of the application
        public DbSet<Flat> Flats { get; set; }
     public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Maintenance> Maintenances { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //Configuring what is the data provider and the connection string for connection

            optionsBuilder.UseSqlServer("Server=Dhivya-pc\\SqlExpress;Database=HousingSociety_EFCore1;integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Setting the global query filter 

            modelBuilder.Entity<Flat>().HasQueryFilter(f => f.IsActive);
            modelBuilder.Entity<Flat>().Property(f => f.IsActive).HasDefaultValue(true);
        }

    }
}