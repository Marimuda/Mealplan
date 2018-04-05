using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diet.Models
{
    public class RecipeIngredients
    {   //There might be a issue with composite key generation here.

        public int RecipeIngredientsID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IngredientID { get; set; }

        [Display(Name = "Amount")]
        [Column("Amount")]
        [Required]
        [StringLength(5)]
        public int IngredientAmount { get; set; }



        public Recipes Recipes { get; set; }
        public Ingredient Ingredients { get; set; }
    }
}
