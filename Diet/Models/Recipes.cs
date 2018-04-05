using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diet.Models
{
    public class Recipes
    {
        [Key]
        public int RecipeID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Name")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]       
        //The RegularExpression requires the first character to be upper case and the remaining characters to be alphabetical
        public string RecipeName { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Provide a clear Recipe description")]
        [Column("Description")]
        [Display(Name = "Description")]
        public string RecipeDescription { get; set; }

        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }
        public virtual ICollection<RecipeRatning> RecipeRatning { get; set; }

    }
}
