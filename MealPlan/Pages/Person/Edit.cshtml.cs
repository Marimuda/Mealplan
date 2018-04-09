using MealPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlan.Pages.Person
{
    public class EditModel : PageModel
    {
        private readonly MealPlan.Data.ApplicationDbContext _context;

        public EditModel(MealPlan.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Persons Persons { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Persons = await _context.Persons.FirstOrDefaultAsync(m => m.PersonId == id);
            Persons = await _context.Persons.FindAsync(id);

            if (Persons == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var personToUpdate = await _context.Persons.FindAsync(Persons.PersonId);           //
                                                                                               //
            if (await TryUpdateModelAsync<Persons>(                                            //
            personToUpdate,                                                                    //
            "persons",                                                                         //
            s => s.Firstname, s => s.Surname))                                                 //
            {                                                                                  //
                await _context.SaveChangesAsync();                                             //
                return RedirectToPage("./Index");                                              //
            }                                                                                  //
                                                                                               //
            return Page();                                                                     //
        }                                                                                      //

        //     _context.Attach(Persons).State = EntityState.Modified;
        //
        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!PersonsExists(Persons.PersonId))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }
        //
        //     return RedirectToPage("./Index");
        // }

        private bool PersonsExists(int id)
        {
            return _context.Persons.Any(e => e.PersonId == id);
        }
    }
}
