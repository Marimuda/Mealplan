using MealPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace MealPlan.Pages.Biodata
{
    public class CreateModel : PageModel
    {
        private readonly MealPlan.Data.ApplicationDbContext _context;

        public CreateModel(MealPlan.Data.ApplicationDbContext context)
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