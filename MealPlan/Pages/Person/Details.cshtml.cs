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
    public class DetailsModel : PageModel
    {
        private readonly MealPlan.Models.MealplanContext _context;

        public DetailsModel(MealPlan.Models.MealplanContext context)
        {
            _context = context;
        }

        public Persons Persons { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Persons = await _context.Persons
                    .Include(s => s.BioData)
                        .ThenInclude(e => e.ActivityLevel)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.PersonId == id);

            //Persons = await _context.Persons.FirstOrDefaultAsync(m => m.PersonId == id);

            if (Persons == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
