using MealPlan.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MealPlan.Pages.Biodata
{
    public class IndexModel : PageModel
    {
        private readonly MealPlan.Data.ApplicationDbContext _context;

        public IndexModel(MealPlan.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BioData> BioData { get; set; }

        public async Task OnGetAsync()
        {
            BioData = await _context.BioData
                .Include(b => b.Person).ToListAsync();
        }
    }
}
