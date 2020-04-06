using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.LineTokens
{
    public class DetailsModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public DetailsModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        public Employee Employee { get; set; }
        public LineToken LineToken { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            if (id == null)
            {
                return NotFound();
            }

            LineToken = await _context.LineToken
                .Include(l => l.Company).FirstOrDefaultAsync(m => m.LineTokenID == id);

            if (LineToken == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
