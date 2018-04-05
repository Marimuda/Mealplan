using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MealPlan.Models;

namespace MealPlan.Pages.Person
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
