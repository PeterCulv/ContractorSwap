using System.ComponentModel.DataAnnotations;

namespace ContractorSwap.Models
{
    public class ContractorModel
    {
        [Key]
        
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Specialties { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    
        public virtual IEnumerable<JobListingModel>? JobListings { get; set; }


    }
}
