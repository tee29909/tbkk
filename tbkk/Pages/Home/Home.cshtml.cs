using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.Home
{
    public class HomeModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;
        public HomeModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employee
                .Include(e => e.Company)
                .Include(e => e.Department)
                .Include(e => e.EmployeeType)
                .Include(e => e.Location)
                .Include(e => e.Position).FirstOrDefaultAsync(m => m.EmployeeID == id);
            
            if (Employee == null)
            {
                return NotFound();
            }
            ViewData["Company_CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyID");
            ViewData["Department_DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "DepartmentID");
            ViewData["Employee_EmployeeTypeID"] = new SelectList(_context.EmployeeType, "EmployeeTypeID", "EmployeeTypeID");
            ViewData["Location_LocationID"] = new SelectList(_context.Location, "LocationID", "LocationID");
            ViewData["Employee_PositionID"] = new SelectList(_context.Position, "PositionID", "PositionID");
            //return RedirectToPage("./../Home/Home", new { id = Employee.EmployeeID });
            return Page();
        }
    }
}