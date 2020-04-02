using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.NewFolder
{
    public class EditModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public EditModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DetailOT DetailOT { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DetailOT = await _context.DetailOT
                .Include(d => d.Employee)
                .Include(d => d.EmployeeAdd)
                .Include(d => d.FoodSet)
                .Include(d => d.OT)
                .Include(d => d.Part).FirstOrDefaultAsync(m => m.DetailOTID == id);

            if (DetailOT == null)
            {
                return NotFound();
            }
           ViewData["Employee_EmpID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID");
           ViewData["Employee_UserAdd_EmpID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID");
           ViewData["FoodSet_FoodSetID"] = new SelectList(_context.FoodSet, "FoodSetID", "FoodSetID");
           ViewData["OT_OTID"] = new SelectList(_context.OT, "OTID", "OTID");
           ViewData["Part_PaetID"] = new SelectList(_context.Part, "PartID", "PartID");
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

            _context.Attach(DetailOT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailOTExists(DetailOT.DetailOTID))
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

        private bool DetailOTExists(int id)
        {
            return _context.DetailOT.Any(e => e.DetailOTID == id);
        }
    }
}
