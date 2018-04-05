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
    public class DeleteModel : PageModel
    {
        private readonly MealPlan.Models.MealplanContext _context;

        public DeleteModel(MealPlan.Models.MealplanContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ActivityLevels = await _context.ActivityLevel.FindAsync(id);

            if (ActivityLevels != null)
            {
                _context.ActivityLevel.Remove(ActivityLevels);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
