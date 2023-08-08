using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractorSwap.Models
{
    public class JobListingModel
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now.Date;

        [Required]
        public string Location { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        
        [ForeignKey("posterId")]
        public int PosterId { get; set; }


        /// <summary>
        /// not in google sheet, added this to capture "accepted bid" from the application model 
    
        [ForeignKey("accepterId")]
        public int AcceptedId { get; set; }

        public virtual IEnumerable<ApplicationModel>? Applications { get; set; }    
    }
}
