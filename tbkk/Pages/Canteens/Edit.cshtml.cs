using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.Canteens
{
    public class EditModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public EditModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Canteen Canteen { get; set; }
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
        Employee = HttpContext.Session.GetLogin(_context.Employee);
            if (id == null)
            {
                return NotFound();
            }

            Canteen = await _context.Canteen
                .Include(c => c.Company).FirstOrDefaultAsync(m => m.CanteenID == id);

            if (Canteen == null)
            {
                return NotFound();
            }
           ViewData["Canteen_CompanyID"] = new SelectList(_context.Company, "CompanyID", "Image");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Canteen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CanteenExists(Canteen.CanteenID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CanteenExists(int id)
        {
            return _context.Canteen.Any(e => e.CanteenID == id);
        }
    }
}
