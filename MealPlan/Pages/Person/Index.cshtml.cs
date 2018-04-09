using MealPlan.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlan.Pages.Person
{
    public class IndexModel : PageModel
    {
        private readonly MealPlan.Data.ApplicationDbContext _context;

        public IndexModel(MealPlan.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }                       //
        public string DateSort { get; set; }                       //
        public string CurrentFilter { get; set; }                  //
        public string CurrentSort { get; set; }                    //
                                                                   //
        public PaginatedList<Persons> Persons { get; set; }

        public async Task OnGetAsync(string sortOrder,
        string currentFilter, string searchString, int? pageIndex)  //
        {
            //Persons = await _context.Persons.ToListAsync();
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "ID" : "";
            DateSort = sortOrder == "Firstname" ? "Firstname" : "Firstname";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString; //

            IQueryable<Persons> personIQ = from s in _context.Persons
                                           select s;

            if (!String.IsNullOrEmpty(searchString))                                        //
            {                                                                               //
                personIQ = personIQ.Where(s => s.Surname.Contains(searchString)          //
                                       || s.Firstname.Contains(searchString));           //
            }

            switch (sortOrder)
            {
                case "ID":
                    personIQ = personIQ.OrderByDescending(s => s.PersonId);
                    break;
                case "Firstname":
                    personIQ = personIQ.OrderBy(s => s.Firstname);
                    break;
                default:
                    personIQ = personIQ.OrderBy(s => s.Surname);
                    break;
            }

            int pageSize = 5;
            Persons = await PaginatedList<Persons>.CreateAsync(
                personIQ.AsNoTracking(), pageIndex ?? 1, pageSize);  // ?? = null-coalescing operator, in this case Return 1 if pageIndex = Null


            //Persons = await personIQ.AsNoTracking().ToListAsync();

        }
    }
}
