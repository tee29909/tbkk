using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.CarTypes
{
    public class DeleteModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public DeleteModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        public Employee Employee { get; set; }
        
        [BindProperty]
        public CarType CarType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            CarType = await _context.CarType
                .Include(c => c.CompanyCar).FirstOrDefaultAsync(m => m.CarTypeID == id);

            if (CarType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                Employee = HttpContext.Session.GetLogin(_context.Employee);
                return NotFound();
            }
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            CarType = await _context.CarType.FindAsync(id);

            if (CarType != null)
            {
               
                _context.CarType.Remove(CarType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
