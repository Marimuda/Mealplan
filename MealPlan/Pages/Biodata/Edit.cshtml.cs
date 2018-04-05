using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MealPlan.Models;

namespace MealPlan.Pages.Biodata
{
    public class EditModel : PageModel
    {
        private readonly MealPlan.Models.MealplanContext _context;

        public EditModel(MealPlan.Models.MealplanContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BioData BioData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BioData = await _context.BioData
                .Include(b => b.Person).FirstOrDefaultAsync(m => m.BioId == id);

            if (BioData == null)
            {
                return NotFound();
            }
           ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "Firstname");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BioData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BioDataExists(BioData.BioId))
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

        private bool BioDataExists(int id)
        {
            return _context.BioData.Any(e => e.BioId == id);
        }
    }
}
