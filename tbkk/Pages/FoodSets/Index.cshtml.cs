using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.FoodSets
{
    public class IndexModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public IndexModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        public IList<FoodSet> FoodSet { get;set; }

        public async Task OnGetAsync()
        {
            FoodSet = await _context.FoodSet
                .Include(f => f.Canteen).ToListAsync();
        }
    }
}
