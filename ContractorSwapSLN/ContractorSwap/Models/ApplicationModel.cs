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
        /*
        [ForeignKey("JobListingId")]
        public int JobListingId { get; set; }
        public JobListingModel JobListing { get; set; }
        */
        [ForeignKey("ContractorId")]
        public int ContractorId { get; set; }   
        public ContractorModel Contractor { get; set; }
        

       
    }
}
