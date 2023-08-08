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
        }

    }
}
