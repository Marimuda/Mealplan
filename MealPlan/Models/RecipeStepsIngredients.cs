using System;
using System.Collections.Generic;

namespace MealPlan.Models
{
    public partial class RecipeStepsIngredients
    {
        public sbyte StepId { get; set; }
        public short Amount { get; set; }
        public short IngredientId { get; set; }
        public int RecipeId { get; set; }

        public Ingredients Ingredient { get; set; }
        public Recipes Recipe { get; set; }
    }
}
