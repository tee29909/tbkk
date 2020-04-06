using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.Points
{
    public class DeleteModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public DeleteModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Point Point { get; set; }
        public Employee Employee { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            if (id == null)
            {
                return NotFound();
            }

            Point = await _context.Point
                .Include(p => p.Part).FirstOrDefaultAsync(m => m.PointID == id);

            if (Point == null)
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

            Point = await _context.Point.FindAsync(id);

            if (Point != null)
            {
                _context.Point.Remove(Point);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
