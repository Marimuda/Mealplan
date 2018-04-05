using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlan.Models;

namespace MealPlan.Pages.ActivityLevel
{
    public class DetailsModel : PageModel
    {
        private readonly MealPlan.Models.MealplanContext _context;

        public DetailsModel(MealPlan.Models.MealplanContext context)
        {
            _context = context;
        }

        public ActivityLevels ActivityLevels { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ActivityLevels = await _context.ActivityLevel
                .Include(a => a.BioData).FirstOrDefaultAsync(m => m.BioId == id);

            if (ActivityLevels == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
