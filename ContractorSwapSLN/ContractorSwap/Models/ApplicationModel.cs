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

        [ForeignKey("JobListingId")]
        public int JobListingId { get; set; }

        [ForeignKey("SeekerId")]
        public int SeekerId { get; set; }   

       
    }
}
