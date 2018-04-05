using System;
using System.Collections.Generic;

namespace MealPlan.Models
{
    public partial class CourseType
    {
        public short CourseIdr { get; set; }
        public int MenuId { get; set; }
        public string CourseType1 { get; set; }

        public MenuCourse MenuCourse { get; set; }
    }
}
