using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diet.Models
{
    public class MenuCourses
    {
        [Key]
        public int CourseID { get; set; }

        [Key]
        [ForeignKey("Menu")]
        public int MenuID { get; set; }
        public Menu Menus { get; set; }


        [StringLength(40, ErrorMessage = "Course name can not be longer than 40 characters.", MinimumLength = 4)]
        [Display(Name = "Course Name")]
        [Required]
        public string CourseName { get; set; }

        [Display(Name = "Image URL")]
        public string CourseImgUrl { get; set; }


        public virtual ICollection<CourseType> CourseTypes { get; set; }
    }
}
