using MealPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MealPlan.Pages.Biodata
{
    public class DetailsModel : PageModel
    {
        private readonly MealPlan.Data.ApplicationDbContext _context;

        public DetailsModel(MealPlan.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
