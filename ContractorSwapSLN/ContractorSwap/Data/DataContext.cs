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

        }

    }
}
