using System;
using System.Collections.Generic;

namespace MealPlan.Models
{
    public partial class Recipes
    {
        public Recipes()
        {
            CourseRecipeChoices = new HashSet<CourseRecipeChoices>();
            RecipeStepsIngredients = new HashSet<RecipeStepsIngredients>();
        }

        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public byte[] RecipeDescription { get; set; }
        public DateTimeOffset ReCreationDate { get; set; }
        public int AccountId { get; set; }

        public Account Account { get; set; }
        public RecipeRatning RecipeRatning { get; set; }
        public ICollection<CourseRecipeChoices> CourseRecipeChoices { get; set; }
        public ICollection<RecipeStepsIngredients> RecipeStepsIngredients { get; set; }
    }
}
