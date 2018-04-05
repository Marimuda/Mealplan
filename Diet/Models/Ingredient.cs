using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diet.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientID { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Give a clear ingredient name")]
        [Column("Name")]
        [Display(Name = "Ingredient Name")]
        public string IngredientName { get; set; }

        public RecipeIngredients RecipeIngredients { get; set; }


    }
}
