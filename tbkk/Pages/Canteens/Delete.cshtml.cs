using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.Canteens
{
    public class DeleteModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public DeleteModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Canteen Canteen { get; set; }
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            Canteen = await _context.Canteen
                .Include(c => c.Company).FirstOrDefaultAsync(m => m.CanteenID == id);

            if (Canteen == null)
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
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            Canteen = await _context.Canteen.FindAsync(id);

            if (Canteen != null)
            {
                _context.Canteen.Remove(Canteen);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
