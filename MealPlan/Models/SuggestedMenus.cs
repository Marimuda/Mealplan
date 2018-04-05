using System;
using System.Collections.Generic;

namespace MealPlan.Models
{
    public partial class SuggestedMenus
    {
        public SuggestedMenus()
        {
            MenuCourse = new HashSet<MenuCourse>();
        }

        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }

        public ICollection<MenuCourse> MenuCourse { get; set; }
    }
}
