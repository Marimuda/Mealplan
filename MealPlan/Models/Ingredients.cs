using System;
using System.Collections.Generic;

namespace MealPlan.Models
{
    public partial class Ingredients
    {
        public Ingredients()
        {
            RecipeStepsIngredients = new HashSet<RecipeStepsIngredients>();
        }

        public short IngredientId { get; set; }
        public string IngredientName { get; set; }

        public ICollection<RecipeStepsIngredients> RecipeStepsIngredients { get; set; }
    }
}
