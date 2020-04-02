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
    public class DeleteModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public DeleteModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LineToken LineToken { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LineToken = await _context.LineToken.FindAsync(id);

            if (LineToken != null)
            {
                _context.LineToken.Remove(LineToken);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
