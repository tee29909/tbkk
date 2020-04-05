using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.CarQueues
{
    public class EditModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public EditModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarQueue CarQueue { get; set; }
        public Employee Employee { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            CarQueue = await _context.CarQueue
                .Include(c => c.CarType)
                .Include(c => c.OT)
                .Include(c => c.Part).FirstOrDefaultAsync(m => m.CarQueueID == id);

            if (CarQueue == null)
            {
                return NotFound();
            }
           ViewData["CarQueue_CarTypeID"] = new SelectList(_context.CarType, "CarTypeID", "CarTypeID");
           ViewData["CarQueue_OTID"] = new SelectList(_context.OT, "OTID", "OTID");
           ViewData["CarQueue_PartID"] = new SelectList(_context.Part, "PartID", "PartID");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            _context.Attach(CarQueue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarQueueExists(CarQueue.CarQueueID))
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

        private bool CarQueueExists(int id)
        {
            return _context.CarQueue.Any(e => e.CarQueueID == id);
        }
    }
}
