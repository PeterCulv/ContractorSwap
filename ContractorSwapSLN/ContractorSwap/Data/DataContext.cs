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
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ContractorSwap8;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
             modelBuilder.Entity<ApplicationModel>()
                .HasOne(a => a.JobListing)
                .WithMany()
                .HasForeignKey(a => a.JobListingId)
                /*.OnDelete(DeleteBehavior.NoAction)*/;

             modelBuilder.Entity<ApplicationModel>()
                .HasOne(a => a.Contractor)
                .WithMany()
                .HasForeignKey(a => a.ContractorId)
                .OnDelete(DeleteBehavior.NoAction);

           
            modelBuilder.Entity<ContractorModel>().HasData(

                new ContractorModel()
                {
                    Id = 1,
                    Name = "John Deere",
                    Carpentery = true,
                    Plumbing = true,
                    General = false,
                    Electrical = false,
                    Address = "baluga",
                    City = "Columbus",
                    State = "Ohio",
                    Zip = "55555",
                    Email = "email",
                    Phone = "5555555555",
                    UserName = "johndeere123",
                    Password = "deerebutstillgoated",
                },
                new ContractorModel()
                {
                    Id = 2,
                    Name = "Francis Charlery",
                    Carpentery = false,
                    Plumbing = false,
                    General = true,
                    Electrical = true,
                    Address = "baluga",
                    City = "Columbus",
                    State = "Ohio",
                    Zip = "55555",
                    Email = "email",
                    Phone = "5555555555",
                    UserName = "frantheman",
                    Password = "francis456",                    


                }) ;
              modelBuilder.Entity<JobListingModel>().HasData(
                 new JobListingModel()
                 {
                     Id = 1,
                     Name = "Test Job",
                     Date = new DateTime(2019, 05, 09),
                     CompletionDate = new DateTime(2023, 09, 23),
                     Address = "baluga",
                     City = "Columbus",
                     State = "Ohio",
                     Zip = "55555",
                     Carpentery = false,
                     Plumbing = false,
                     General = true,
                     Electrical = false,
                     Description = "Ceiling fan installation: Master Bedroom",
                     ContractorId = 1
                 },
                 new JobListingModel()
                 {
                     Id = 2,
                     Name = "Secondary Job",
                     Date = new DateTime(2023, 06, 09),
                     CompletionDate = new DateTime(2023, 08, 30),
                     Address = "baluga",
                     City = "Columbus",
                     State = "Ohio",
                     Zip = "55555",
                     Carpentery = false,
                     Plumbing = false,
                     General = true,
                     Electrical = true,
                     Description = "Install a hot tub for a Chihuaha",
                     ContractorId = 2
                 });
             modelBuilder.Entity<ApplicationModel>().HasData(
                 new ApplicationModel()
                 {
                     Id = 1,
                     Bid = 750.00,
                     JobListingId = 1,
                     ContractorId = 2,
                     Date = new DateTime(2023, 06, 23)
                 },
                 new ApplicationModel()
                 {
                     Id = 2,
                     Bid = 5800.00,
                     JobListingId = 2,
                     ContractorId = 1,
                     Date = new DateTime(2023, 07, 23)
                 });

        }

    }
}
