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


                },
                new ContractorModel()
                {
                    Id = 3,
                    Name = "Stone Chalmers",
                    Carpentery = false,
                    Plumbing = true,
                    General = false,
                    Electrical = true,
                    Address = "8017 Yager Way",
                    City = "Columbus",
                    State = "Ohio",
                    Zip = "55555",
                    Email = "stonechalmers49@aol.com",
                    Phone = "2093541980",
                    UserName = "StoneyC",
                    Password = "ChalStone1975",
                },
                new ContractorModel()
                {
                    Id = 4,
                    Name = "Tim Smith",
                    Carpentery = true,
                    Plumbing = false,
                    General = true,
                    Electrical = true,
                    Address = "144 Spruce St",
                    City = "Columbus",
                    State = "Ohio",
                    Zip = "55555",
                    Email = "smittyman12@aol.com",
                    Phone = "8179314754",
                    UserName = "TimmySmit",
                    Password = "tinmansmitty",


                });
            modelBuilder.Entity<JobListingModel>().HasData(
                 new JobListingModel()
                 {
                     Id = 1,
                     Name = "Ceiling Fan Install",
                     Date = new DateTime(2023, 08, 09),
                     CompletionDate = new DateTime(2023, 09, 09),
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
                     Name = "Tiny Hot Tub For Dog",
                     Date = new DateTime(2023, 08, 23),
                     CompletionDate = new DateTime(2023, 08, 24),
                     Address = "baluga",
                     City = "Columbus",
                     State = "Ohio",
                     Zip = "55555",
                     Carpentery = false,
                     Plumbing = false,
                     General = true,
                     Electrical = true,
                     Description = "Install a hot tub for a Chihuaha",
                     ContractorId = 2,
                 
                 },
                 new JobListingModel()
                 {
                     Id = 3,
                     Name = "Master Bathroom Shower",
                     Date = new DateTime(2023, 08, 15),
                     CompletionDate = new DateTime(2023, 09, 05),
                     Address = "809 ",
                     City = "Columbus",
                     State = "Ohio",
                     Zip = "55555",
                     Carpentery = false,
                     Plumbing = true,
                     General = false,
                     Electrical = true,
                     Description = "Install new shower in master bathroom.",
                     ContractorId = 3,
                 },
                 new JobListingModel()
                 {
                     Id = 4,
                     Name = "Install Whole Home Sound System",
                     Date = new DateTime(2023, 07, 29),
                     CompletionDate = new DateTime(2023, 08, 23),
                     Address = "19 BelAir St",
                     City = "Columbus",
                     State = "Ohio",
                     Zip = "55555",
                     Carpentery = false,
                     Plumbing = true,
                     General = false,
                     Electrical = true,
                     Description = "Install home sound system throughout the house. I have all the new speakers on site.",
                     ContractorId = 3
                 },
                 new JobListingModel()
                 {
                     Id = 5,
                     Name = "Rewire House",
                     Date = new DateTime(2023, 06, 09),
                     CompletionDate = new DateTime(2023, 08, 30),
                     Address = "86 Elm Dr",
                     City = "Columbus",
                     State = "Ohio",
                     Zip = "55555",
                     Carpentery = false,
                     Plumbing = true,
                     General = false,
                     Electrical = true,
                     Description = "My husband and I recently bought the house and have to rewire the whole house to be up to code.",
                     ContractorId = 3,
                 },
                 new JobListingModel()
                 {
                     Id = 6,
                     Name = "Build She-Shed",
                     Date = new DateTime(2023, 07, 19),
                     CompletionDate = new DateTime(2023, 08, 02),
                     Address = "651 Oak St",
                     City = "Columbus",
                     State = "Ohio",
                     Zip = "55555",
                     Carpentery = false,
                     Plumbing = false,
                     General = true,
                     Electrical = false,
                     Description = "I need a 24 x 24 shed built so I have a place for my yoga.",
                     ContractorId = 1
                 },
                 new JobListingModel()
                 {
                     Id = 7,
                     Name = "Outdoor Grill",
                     Date = new DateTime(2023, 07, 09),
                     CompletionDate = new DateTime(2023, 08, 30),
                     Address = "305 Center Ct",
                     City = "Columbus",
                     State = "Ohio",
                     Zip = "55555",
                     Carpentery = true,
                     Plumbing = false,
                     General = true,
                     Electrical = true,
                     Description = "I want a 20 x 20 outdoor grill with a bar.",
                     ContractorId = 4,
                 });
            modelBuilder.Entity<ApplicationModel>().HasData(
                 new ApplicationModel()
                 {
                     Id = 1,
                     Bid = 750.00,
                     JobListingId = 1,
                     ContractorId = 3,
                     Date = new DateTime(2023, 06, 23)
                 },
                 new ApplicationModel()
                 {
                     Id = 2,
                     Bid = 800.00,
                     JobListingId = 2,
                     ContractorId = 1,
                     Date = new DateTime(2023, 07, 23)
                 },
                 new ApplicationModel()
                 {
                     Id = 3,
                     Bid = 1200.00,
                     JobListingId = 4,
                     ContractorId = 1,
                     Date = new DateTime(2023, 06, 23)
                 },
                 new ApplicationModel()
                 {
                     Id = 4,
                     Bid = 5800.00,
                     JobListingId = 5,
                     ContractorId = 2,
                     Date = new DateTime(2023, 07, 23)
                 },
                 new ApplicationModel()
                 {
                     Id = 5,
                     Bid = 850.00,
                     JobListingId = 3,
                     ContractorId = 4,
                     Date = new DateTime(2023, 06, 23)
                 },
                 new ApplicationModel()
                 {
                     Id = 6,
                     Bid = 3350.00,
                     JobListingId = 7,
                     ContractorId = 3,
                     Date = new DateTime(2023, 07, 23)
                 },
                 new ApplicationModel()
                 {
                     Id = 7,
                     Bid = 825.00,
                     JobListingId = 3,
                     ContractorId = 2,
                     Date = new DateTime(2023, 06, 23)
                 },
                 new ApplicationModel()
                 {
                     Id = 8,
                     Bid = 875.00,
                     JobListingId = 3,
                     ContractorId = 1,
                     Date = new DateTime(2023, 07, 23)
                 },
                 new ApplicationModel()
                 {
                     Id = 9,
                     Bid = 750.00,
                     JobListingId = 6,
                     ContractorId = 4,
                     Date = new DateTime(2023, 06, 23)
                 },
                 new ApplicationModel()
                 {
                     Id = 10,
                     Bid = 5800.00,
                     JobListingId = 6,
                     ContractorId = 3,
                     Date = new DateTime(2023, 07, 23)
                 });

        }

    }
}
