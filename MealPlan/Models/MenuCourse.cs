using System;
using System.Collections.Generic;

namespace MealPlan.Models
{
    public partial class MenuCourse
    {
        public MenuCourse()
        {
            CourseRecipeChoices = new HashSet<CourseRecipeChoices>();
        }

        public short CourseId { get; set; }
        public int MenuId { get; set; }
        public string CourseName { get; set; }
        public string CimageUrl { get; set; }

        public SuggestedMenus Menu { get; set; }
        public CourseType CourseType { get; set; }
        public ICollection<CourseRecipeChoices> CourseRecipeChoices { get; set; }
    }
}
