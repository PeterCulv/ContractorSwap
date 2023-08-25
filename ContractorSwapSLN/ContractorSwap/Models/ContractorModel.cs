using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractorSwap.Models
{
    public class ContractorModel
    {
        [Key]

        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool Carpentery { get; set; } = false;
        [Required]
        public bool Plumbing { get; set; } = false;
        [Required]
        public bool General { get; set; } = false;
        [Required]
        public bool Electrical { get; set; } = false;

        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        
        public List<string> Specialties { get; set; }
        public void AddSpecialties()
        {
            Specialties.Clear();
            if(Carpentery)
            {
                Specialties.Add("Carpentry");
            }
            if (Plumbing)
            {
                Specialties.Add("Plumbing");
            }
            if (General)
            {
                Specialties.Add("General");
            }
            if (Electrical)
            {
                Specialties.Add("Electrical");
            }
        }
        [NotMapped]
        public virtual IEnumerable<ApplicationModel>? AcceptedJobs { get; set; }  
    
        public virtual IEnumerable<JobListingModel>? JobListings { get; set; }


    }
}
