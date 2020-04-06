using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.CompanyCars
{
    public class IndexModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public IndexModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        public Employee Employee { get; set; }
        public IList<CompanyCar> CompanyCar { get;set; }

        public async Task OnGetAsync()
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            CompanyCar = await _context.CompanyCar
                .Include(c => c.Company).ToListAsync();
        }
    }
}
