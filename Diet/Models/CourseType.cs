using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diet.Models
{
    public class CourseType
    {

        public enum Type
        {
            Breakfast, Elevenses, Brunch, Lunch, Supper, Dinner, Snack
            //https://en.wikipedia.org/wiki/Meal
        }

        [ForeignKey("MenuCourses")]
        [Key]
        public int CourseID { get; set; }

        [DisplayFormat(NullDisplayText = "No Course Type Selected")]
        [Column("Type")]
        [Display(Name = "Course Type")]
        public Type? MealType { get; set; }

        public MenuCourses MenuCourses { get; set; }


    }
}
