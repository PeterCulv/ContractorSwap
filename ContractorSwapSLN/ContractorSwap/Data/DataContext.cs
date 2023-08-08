﻿using ContractorSwap.Models;
using Microsoft.EntityFrameworkCore;

namespace ContractorSwap.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ContractorModel> Contractors { get; set; }
        public DbSet<JobListingModel> Jobs { get; set; }
        public DbSet<ApplicationModel> Applications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ContractorSwap;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobListingModel>().HasData(
                new JobListingModel()
                {
                    Id = 1,
                    Name = "Test Job",
                    Date = new DateTime(2019, 05, 09),
                    Location = "666 Elm Street, Aurora, IL",
                    Description = "Ceiling fan installation: Master Bedroom",
                    PosterId = 1
                },
                new JobListingModel()
                {
                    Id = 2,
                    Name = "Secondary Job",
                    Date = new DateTime(2023, 06, 09),
                    Location = "1111 Hampton Hills Ct., Hamptons, CT",
                    Description = "Install a hot tub for a Chihuaha",
                    PosterId = 2
                });
            modelBuilder.Entity<ApplicationModel>().HasData(
                new ApplicationModel()
                {
                    Id = 1,
                    Bid = 750.00,
                    JobListingId = 1,
                    SeekerId = 2
                },
                new ApplicationModel()
                {
                    Id = 2,
                    Bid = 5800.00,
                    JobListingId = 2,
                    SeekerId = 1
                });
        }

    }
}
