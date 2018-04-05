using System;
using System.Collections.Generic;

namespace MealPlan.Models
{
    public partial class RecipeRatning
    {
        public int RecipeId { get; set; }
        public short? RecipeRating { get; set; }

        public Recipes Recipe { get; set; }
    }
}
