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
    public class PartModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public PartModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Debug = 0;
            await OnLode();
            return Page();
        }

        private async Task OnLode()
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            Partlist = await _context.Part.ToListAsync();
        }

        [BindProperty]
        public Part Part { get; set; }

        public IList<Part>  Partlist { get; set; }
        
        public Employee Employee { get; set; }
        public int Debug { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Debug = 0;
            var check = 0;
            if (Part.Name == null)
            {
                check = 1;
                ModelState.AddModelError("Part.Name", "The Name field is required.");

            }
            if (Part.Price <= 0)
            {
                check = 1;
                ModelState.AddModelError("Part.Price", "The Price field is required.");
            }



            if (check == 1)
            {
                Debug = 1;
                await OnLode();
                return Page();
            }

            
            _context.Part.Add(Part);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Part");
        }
        [BindProperty]
        public Part PartEdit { get; set; }
        public async Task<IActionResult> OnPostEditAsync()
        {
            Debug = 0;
            var check = 0;
            if (PartEdit.Name == null)
            {
                check = 1;
                ModelState.AddModelError("PartEdit.Name", "The Name field is required.");

            }
            if (PartEdit.Price <= 0)
            {
                check = 1;
                ModelState.AddModelError("PartEdit.Price", "The Price field is required.");
            }



            if (check == 1)
            {
                Debug = 2;
                await OnLode();
                return Page();
            }

            _context.Attach(PartEdit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartExists(PartEdit.PartID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Part");
        }

        private bool PartExists(int id)
        {
            return _context.Part.Any(e => e.PartID == id);
        }
    }
}
