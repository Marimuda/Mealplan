using System;
using System.Collections.Generic;

namespace MealPlan.Models
{
    public partial class CourseRecipeChoices
    {
        public short CourseId { get; set; }
        public int? MenuId { get; set; }
        public int RecipesId { get; set; }

        public MenuCourse MenuCourse { get; set; }
        public Recipes Recipes { get; set; }
    }
}
