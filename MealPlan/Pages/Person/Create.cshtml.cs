using MealPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace MealPlan.Pages.Person
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
            return Page();
        }

        [BindProperty]
        public Persons Persons { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyPerson = new Persons();
            //
            if (await TryUpdateModelAsync<Persons>(                                            //
            emptyPerson,                                                                        //
            "persons",                                                                         //
            s => s.Firstname, s => s.Surname))                                                 //
            {
                _context.Persons.Add(Persons);                                                 //
                await _context.SaveChangesAsync();                                             //
                return RedirectToPage("./Index");                                              //
            }
            return null;
            //await _context.SaveChangesAsync();
            //
            //return RedirectToPage("./Index");
        }
    }

}
