using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using tbkk.Models;

namespace tbkk.Pages.tesetOT
{
    public class CreateModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public CreateModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CarType_CarTypeID"] = new SelectList(_context.CarType, "CarTypeID", "CarTypeID");
        ViewData["Employee_EmpID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID");
        ViewData["FoodSet_FoodSetID"] = new SelectList(_context.FoodSet, "FoodSetID", "FoodSetID");
        ViewData["OT_OTID"] = new SelectList(_context.OT, "OTID", "OTID");
        ViewData["Part_PaetID"] = new SelectList(_context.Part, "PartID", "PartID");
            return Page();
        }

        [BindProperty]
        public DetailOT DetailOT { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DetailOT.Add(DetailOT);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
