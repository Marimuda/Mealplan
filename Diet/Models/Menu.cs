using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diet.Models
{
    public class Menu
    {
        public int MenuID { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Menu name can not be longer than 40 characters.", MinimumLength = 4)]
        public string MenuName { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Description The Menu")]
        [Display(Name = "Activity Description")]
        public string MenuDescription { get; set; }

        [StringLength(1000, MinimumLength = 10, ErrorMessage = "The Image URL is longer than 1000 characters, Use a URL-shortner ")]
        [Display(Name = "Image URL")]
        public string MenuImgUrl { get; set; }

    }
}
