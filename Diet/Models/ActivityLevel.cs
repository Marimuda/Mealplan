using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diet.Models
{
    public class ActivityLevel
    {

        [Key]
        [ForeignKey("BioData")]
        public int UserID { get; set; }
        public BioData BioData { get; set; }

        [Required]
        [StringLength(1000,MinimumLength = 5, ErrorMessage = "Provide a clear description about the activity level")]
        [Display(Name = "Activity Description")]
        public string ActivityDescription { get; set; }

        [Range(0, 5)]
        public int Activity { get; set; }

    }
}
