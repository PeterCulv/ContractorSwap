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
        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime CompletionDate { get; set; }
        public string DaysSince()
        {
            DateTime today = DateTime.Now;
            var diff = today - Date;
            if (diff.TotalHours < 24)
            {
                return ($"{diff.Hours} Hours Ago");
            }
            if (diff.TotalDays < 30)
            {   if(diff.Days == 1)
                {
                    return ($"{diff.Days} Day Ago");
                }
                return ($"{diff.Days} Days Ago");

            }
            if (diff.TotalDays/7 < 31)
            {
                if(diff.Days/30 == 1)
                {
                    return ($"{diff.Days / 30} Month Ago");
                }
                return ($"{diff.Days/30} Months Ago");
            }
            if (diff.TotalDays/30 > 11)
            {
                if (diff.Days / 365 == 1)
                {
                    return ($"{diff.Days / 365} Year Ago");
                }
                return ($"{diff.Days / 365} Years Ago");
            }
            else { return ($"{diff.Days / 7} Weeks Ago"); }
        }

        [Required]
        public string Address { get; set; }
        [Required] 
        public string City { get; set; }
        [Required] 
        public string Zip { get; set; }
        [Required] 
        public string State { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public bool Carpentery { get; set; } = false;
        public bool Plumbing { get; set; } = false;
        public bool General { get; set; } = false;
        public bool Electrical { get; set; } = false;

        [ForeignKey("ContractorId")]
        public int ContractorId { get; set; }
        public virtual ContractorModel? Contractor { get; set; }

        public virtual IEnumerable<ApplicationModel>? Applications { get; set; }    
    }
}
