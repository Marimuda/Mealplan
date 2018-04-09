using MealPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MealPlan.Pages.Person
{
    public class DetailsModel : PageModel
    {
        private readonly MealPlan.Data.ApplicationDbContext _context;

        public DetailsModel(MealPlan.Data.ApplicationDbContext context)
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
