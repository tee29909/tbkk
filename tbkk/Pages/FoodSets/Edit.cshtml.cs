using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.FoodSets
{
    public class EditModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public EditModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FoodSet FoodSet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FoodSet = await _context.FoodSet
                .Include(f => f.Canteen).FirstOrDefaultAsync(m => m.FoodSetID == id);

            if (FoodSet == null)
            {
                return NotFound();
            }
           ViewData["Canteen_CanteenID"] = new SelectList(_context.Canteen, "CanteenID", "CanteenID");
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

            _context.Attach(FoodSet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodSetExists(FoodSet.FoodSetID))
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

        private bool FoodSetExists(int id)
        {
            return _context.FoodSet.Any(e => e.FoodSetID == id);
        }
    }
}
