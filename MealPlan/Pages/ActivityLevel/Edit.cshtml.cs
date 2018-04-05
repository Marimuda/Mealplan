using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MealPlan.Models;

namespace MealPlan.Pages.ActivityLevel
{
    public class EditModel : PageModel
    {
        private readonly MealPlan.Models.MealplanContext _context;

        public EditModel(MealPlan.Models.MealplanContext context)
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
           ViewData["BioId"] = new SelectList(_context.BioData, "BioId", "Gender");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ActivityLevels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityLevelsExists(ActivityLevels.BioId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ActivityLevelsExists(int id)
        {
            return _context.ActivityLevel.Any(e => e.BioId == id);
        }
    }
}
