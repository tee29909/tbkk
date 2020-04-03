using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using tbkk.Models;

namespace tbkk.Pages.CarQueues
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
        ViewData["CarQueue_CarTypeID"] = new SelectList(_context.CarType, "CarTypeID", "CarTypeID");
        ViewData["CarQueue_OTID"] = new SelectList(_context.OT, "OTID", "OTID");
        ViewData["CarQueue_PartID"] = new SelectList(_context.Part, "PartID", "PartID");
            return Page();
        }

        [BindProperty]
        public CarQueue CarQueue { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CarQueue.Add(CarQueue);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
