using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using tbkk.Models;

namespace tbkk.Pages.Canteens
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
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            ViewData["Canteen_CompanyID"] = new SelectList(_context.Company, "CompanyID", "Image");
            return Page();
        }
public Employee Employee { get; set; }
        [BindProperty]
        public Canteen Canteen { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Canteen.Add(Canteen);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
