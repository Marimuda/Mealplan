using MealPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MealPlan.Pages.Biodata
{
    public class DeleteModel : PageModel
    {
        private readonly MealPlan.Data.ApplicationDbContext _context;

        public DeleteModel(MealPlan.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BioData = await _context.BioData.FindAsync(id);

            if (BioData != null)
            {
                _context.BioData.Remove(BioData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
