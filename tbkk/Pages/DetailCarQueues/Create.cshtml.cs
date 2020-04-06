using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using tbkk.Models;

namespace tbkk.Pages.DetailCarQueues
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
            ViewData["DetailCarQueue_CarQueueID"] = new SelectList(_context.CarQueue, "CarQueueID", "CarQueueID");
        ViewData["DetailCarQueue_EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID");
            return Page();
        }

        [BindProperty]
        public DetailCarQueue DetailCarQueue { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DetailCarQueue.Add(DetailCarQueue);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
