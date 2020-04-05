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
    public class FoodSetModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public FoodSetModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        public IList<FoodSet>  FoodSetList { get; set; }
        public Employee Employee { get; set; }
        public Canteen Canteen { get; set; }
        public int Debug { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Debug = 0;
              await OnLode(id);
            return Page();
        }

        private async Task OnLode(int id)
        {
            Canteen = await _context.Canteen.FirstOrDefaultAsync(e => e.CanteenID == id );
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            FoodSetList = await _context.FoodSet
              .Include(f => f.Canteen).Where(a => a.Canteen_CanteenID == id && !a.NameSet.Equals("No")).ToListAsync();
        }

        [BindProperty]
        public FoodSet FoodSet { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            Debug = 0;
            var check = 0;
            if (FoodSet.FoodSetcoManul == null)
            {
                check = 1;
                ModelState.AddModelError("FoodSet.FoodSetcoManul", "The FoodSetcoManul field is required.");
            }
            if (FoodSet.NameSet == null)
            {
                check = 1;
                ModelState.AddModelError("FoodSet.NameSet", "The NameSet field is required.");
            }
            if (FoodSet.Price <= 0)
            {
                check = 1;
                ModelState.AddModelError("FoodSet.Price", "The Price field is required.");
            }
         

            if (check == 1)
            {
                Debug = 1;
                await OnLode(FoodSet.Canteen_CanteenID);
                return Page();
            }



            if (FoodSet.NameSet.Equals("No"))
            {
                ModelState.AddModelError("FoodSet.NameSet", "The NameSet must not be 'No'");
                await OnLode(FoodSetEdit.Canteen_CanteenID);
                return Page();
            }

            _context.FoodSet.Add(FoodSet);
            await _context.SaveChangesAsync();
            
            return RedirectToPage("./FoodSet", new { id = FoodSet.Canteen_CanteenID});
        }



        [BindProperty]
        public FoodSet FoodSetEdit { get; set; }

        public async Task<IActionResult> OnPostEditAsync()
        {





            Debug = 0;
            var check = 0;
            if (FoodSetEdit.FoodSetcoManul == null)
            {
                check = 1;
                ModelState.AddModelError("FoodSetEdit.FoodSetcoManul", "The FoodSetcoManul field is required.");
            }
            if (FoodSetEdit.NameSet == null)
            {
                check = 1;
                ModelState.AddModelError("FoodSetEdit.NameSet", "The NameSet field is required.");
            }
            if (FoodSetEdit.Price <= 0)
            {
                check = 1;
                ModelState.AddModelError("FoodSetEdit.Price", "The Price field is required.");
            }


            if (check == 1)
            {
                Debug = 2;
                await OnLode(FoodSetEdit.Canteen_CanteenID);
                return Page();
            }








          
            if (FoodSetEdit.NameSet.Equals("No"))
            {
                ModelState.AddModelError("FoodSetEdit.NameSet", "The NameSet must not be 'No'");
                await OnLode(FoodSetEdit.Canteen_CanteenID);
                return Page();
            }

            _context.Attach(FoodSetEdit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodSetExists(FoodSetEdit.FoodSetID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./FoodSet", new { id = FoodSetEdit.Canteen_CanteenID });
        }



        public async Task<IActionResult> OnPostCloseAsync(int id)
        {
           
            var Close = await _context.FoodSet.FirstOrDefaultAsync(e => e.FoodSetID == id);
            Close.Status = "Close";
            _context.Attach(Close).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodSetExists(Close.FoodSetID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./FoodSet", new { id = Close.Canteen_CanteenID });
        }


        public async Task<IActionResult> OnPostOpenAsync(int id)
        {
            
            var Open = await _context.FoodSet.FirstOrDefaultAsync(e => e.FoodSetID == id);
            Open.Status = "Open";
            _context.Attach(Open).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodSetExists(Open.FoodSetID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./FoodSet", new { id = Open.Canteen_CanteenID });
        }

        private bool FoodSetExists(int id)
        {
            return _context.FoodSet.Any(e => e.FoodSetID == id);
        }
    }
}
