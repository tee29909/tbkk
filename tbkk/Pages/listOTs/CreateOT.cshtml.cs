using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.listOTs
{
    public class CreateOTModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;
        private static int? a;
        public CreateOTModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        public Employee Employee { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id,int? Did)
        {
            if (id == null)
            {
                return NotFound();
            }


            a = id;

            OT = await _context.OT.FirstOrDefaultAsync(m => m.OTID == Did);

            if (OT == null)
            {
                return NotFound();
            }



            Employee = await _context.Employee
            .Include(e => e.Company)
            .Include(e => e.Department)
            .Include(e => e.EmployeeType)
            .Include(e => e.Location)
            .Include(e => e.Position).FirstOrDefaultAsync(m => m.EmployeeID == id);


            ViewData["CarType_CarTypeID"] = new SelectList(_context.CarType, "CarTypeID", "CarTypeID");
            ViewData["Employee_EmpID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID");
            ViewData["FoodSet_FoodSetID"] = new SelectList(_context.FoodSet, "FoodSetID", "FoodSetID");
            ViewData["OT_OTID"] = new SelectList(_context.OT, "OTID", "OTID");
            ViewData["Part_PaetID"] = new SelectList(_context.Part, "PartID", "PartID");

            return Page();
        }

        [BindProperty]
        public OT OT { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OT.Add(OT);
            await _context.SaveChangesAsync();

            return RedirectToPage("./../listOTs/manageOT", new { id = a });
        }
    }
}
