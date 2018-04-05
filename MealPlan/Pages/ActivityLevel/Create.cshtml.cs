using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MealPlan.Models;

namespace MealPlan.Pages.ActivityLevel
{
    public class CreateModel : PageModel
    {
        private readonly MealPlan.Models.MealplanContext _context;

        public CreateModel(MealPlan.Models.MealplanContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BioId"] = new SelectList(_context.BioData, "BioId", "Gender");
            return Page();
        }

        [BindProperty]
        public ActivityLevels ActivityLevels { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ActivityLevel.Add(ActivityLevels);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}