using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlan.Models;

namespace MealPlan.Pages.Biodata
{
    public class IndexModel : PageModel
    {
        private readonly MealPlan.Models.MealplanContext _context;

        public IndexModel(MealPlan.Models.MealplanContext context)
        {
            _context = context;
        }

        public IList<BioData> BioData { get;set; }

        public async Task OnGetAsync()
        {
            BioData = await _context.BioData
                .Include(b => b.Person).ToListAsync();
        }
    }
}
