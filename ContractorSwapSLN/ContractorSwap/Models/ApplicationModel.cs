using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractorSwap.Models
{
    public class ApplicationModel
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        public double Bid { get; set; }
        public bool accepted { get; set; } = false;

        public int JobListingId { get; set; }
        [ForeignKey("JobListingId")]
        
        public virtual JobListingModel? JobListing { get; set; }
        
        public int ContractorId { get; set; }
        [ForeignKey("ContractorId")]
          
        public virtual ContractorModel? Contractor { get; set; }
        

       
    }
}
