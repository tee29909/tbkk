using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using tbkk.Models;

namespace tbkk.Pages.CompanyCars
{
    public class CreateModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public CreateModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        public Employee Employee { get; set; }
        public IActionResult OnGet()
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            ViewData["Company_CompanyID"] = new SelectList(_context.Company, "CompanyID", "Image");
            return Page();
        }

        [BindProperty]
        public CompanyCar CompanyCar { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CompanyCar.Add(CompanyCar);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
