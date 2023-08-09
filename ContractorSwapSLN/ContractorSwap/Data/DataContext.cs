using ContractorSwap.Models;
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
            modelBuilder.Entity<ContractorModel>().HasData(
                new ContractorModel()
                {
                    Id = 1,
                    Name = "John Deere",
                    Specialties = "Landscaping",
                    Location = "Grand Detour, Illinois",
                    UserName = "johndeere123",
                    Password = "deerebutstillgoated"
                },
                new ContractorModel()
                {
                    Id = 2,
                    Name = "Francis Charlery",
                    Specialties = "Carpenrty",
                    Location = "Hartford, Connecticut",
                    UserName = "frantheman",
                    Password = "francis456"

                });
            modelBuilder.Entity<JobListingModel>().HasData(
                new JobListingModel()
                {
                    Id = 1,
                    Name = "Test Job",
                    Date = new DateTime(2019, 05, 09),
                    Location = "666 Elm Street, Aurora, IL",
                    Description = "Ceiling fan installation: Master Bedroom",
                    ContractorId = 1
                },
                new JobListingModel()
                {
                    Id = 2,
                    Name = "Secondary Job",
                    Date = new DateTime(2023, 06, 09),
                    Location = "1111 Hampton Hills Ct., Hamptons, CT",
                    Description = "Install a hot tub for a Chihuaha",
                    ContractorId = 2
                });
            modelBuilder.Entity<ApplicationModel>().HasData(
                new ApplicationModel()
                {
                    Id = 1,
                    Bid = 750.00,
                   /* JobListingId = 1,*/
                    ContractorId = 2
                },
                new ApplicationModel()
                {
                    Id = 2,
                    Bid = 5800.00,
                  /*  JobListingId = 2,*/
                    ContractorId = 1
                });
           /* modelBuilder.Entity<ApplicationModel>()
                .HasOne(a => a.JobListing)
                .WithMany()
                .HasForeignKey(a => a.JobListingId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApplicationModel>()
                .HasOne(a => a.Contractor)
                .WithMany()
                .HasForeignKey(a => a.ContractorId);*/
        }

    }
}
