using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlan.Models;

namespace MealPlan.Pages.Person
{
    public class DeleteModel : PageModel
    {
        private readonly MealPlan.Models.MealplanContext _context;

        public DeleteModel(MealPlan.Models.MealplanContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Persons Persons { get; set; }
        public string ErrorMessage { get; set; } //

        //public async Task<IActionResult> OnGetAsync(int? id)
        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Persons = await _context.Persons
                .AsNoTracking()     //
                .FirstOrDefaultAsync(m => m.PersonId == id);

            if (Persons == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Persons = await _context.Persons.FindAsync(id);

            var Persons = await _context.Persons
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.PersonId == id);

            // if (Persons != null)
            // {
            //     _context.Persons.Remove(Persons);
            //     await _context.SaveChangesAsync();
            // }
            //return RedirectToPage("./Index");

            if (Persons == null)
            {
                return NotFound();
            }

            try
            {
                _context.Persons.Remove(Persons);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id = id, saveChangesError = true });
            }
        }
    }
}
