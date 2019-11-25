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
    public class addOTModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public addOTModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }



        [BindProperty]
        public DetailOT DetailOT { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        public Employee Employee { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DetailOT.Add(DetailOT);
            await _context.SaveChangesAsync();

            return RedirectToPage("./../listOTs/listOT", new { id = DetailOT.Employee_EmpID });
         
        }
      
        public OT OT { get; set; }



        public IList<DetailOT> DetailOT2 { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }




            DetailOT2 = await _context.DetailOT
              .Include(d => d.CarType)
              .Include(d => d.Employee)
              .Include(d => d.FoodSet)
              .Include(d => d.OT)
              .Include(d => d.Part).ToListAsync();

            DetailOT2 = DetailOT2.Where(d => d.Employee_EmpID == id).ToList();
            DetailOT2 = DetailOT2.Where(d => d.TimeStart.Date.Equals(DateTime.Today.Date)).ToList();

           






            OT = await _context.OT.FirstOrDefaultAsync(m => m.OTID == id);




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



            if (DetailOT2.Any())
            {

                return RedirectToPage("./../listOTs/listOT", new { id = Employee.EmployeeID });
            }

            if (Employee == null)
            {
                return NotFound();
            }

            ViewData["CarType_CarTypeID"] = new SelectList(_context.CarType, "CarTypeID", "CarTypeID");
            ViewData["Employee_EmpID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID");
            ViewData["FoodSet_FoodSetID"] = new SelectList(_context.FoodSet, "FoodSetID", "FoodSetID");
            ViewData["OT_OTID"] = new SelectList(_context.OT, "OTID", "OTID");
            ViewData["Part_PaetID"] = new SelectList(_context.Part, "PartID", "PartID");
           
            return Page();
        }
    }
}
