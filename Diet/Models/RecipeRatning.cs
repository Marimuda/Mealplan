using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diet.Models
{
    public class RecipeRatning
    {
        [Key]
        [ForeignKey("Recipes")]
        public int RecipeID { get; set; }
        public virtual Recipes Recipes { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 1)]
        [Column("Ratning")]
        [Display(Name = "Recipe Ratning")]
        public int RecipeRating { get; set; }

    }
}
