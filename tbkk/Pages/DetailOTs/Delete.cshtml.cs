using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.DetailOTs
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
        public DetailOT DetailOT { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            if (id == null)
            {
                return NotFound();
            }

            DetailOT = await _context.DetailOT
                .Include(d => d.Employee)
                .Include(d => d.EmployeeAdd)
                .Include(d => d.FoodSet)
                .Include(d => d.OT)
                .Include(d => d.Point).FirstOrDefaultAsync(m => m.DetailOTID == id);

            if (DetailOT == null)
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

            DetailOT = await _context.DetailOT.FindAsync(id);

            if (DetailOT != null)
            {
                _context.DetailOT.Remove(DetailOT);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
