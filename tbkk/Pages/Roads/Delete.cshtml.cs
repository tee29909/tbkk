using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.Roads
{
    public class DeleteModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public DeleteModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Part Part { get; set; }
        public Employee Employee { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            if (id == null)
            {
                return NotFound();
            }

            Part = await _context.Part.FirstOrDefaultAsync(m => m.PartID == id);

            if (Part == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            if (id == null)
            {
                return NotFound();
            }

            Part = await _context.Part.FindAsync(id);

            if (Part != null)
            {
                _context.Part.Remove(Part);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
