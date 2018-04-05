using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MealPlan.Models;

namespace MealPlan.Pages.Biodata
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
        ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "Firstname");
            return Page();
        }

        [BindProperty]
        public BioData BioData { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BioData.Add(BioData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}