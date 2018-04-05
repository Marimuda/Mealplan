using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diet.Models
{
    public class BioData
    {
        [Key]
        [ForeignKey("Users")]                   //[ForeignKey] on the foreign key property in the dependent entity
        public int UserID { get; set; }
        public Users Users { get; set; }

        [Required]
        [StringLength(3)]
        public string Weight { get; set; }

        [Required]
        [StringLength(3)]
        public string Height { get; set; }

        [Required]
        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] 
        public DateTime Birthday { get; set; }

        //   [Display(Name = "Active Metabolic Rate")]
        //   public string AMR
        //   {
        //       //get { return LastName + ", " + FirstMidName; }        Find equation
        //   }

        public ActivityLevel ActivityLevel { get; set; }

    }
}
