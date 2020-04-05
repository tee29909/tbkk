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
    public class ManageCanteenModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public ManageCanteenModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        public Employee Employee { get; set; }
        public Canteen select { get; set; }
        public IList<Canteen>  CanteenList { get; set; }
        public int Debug { get; set; }
        
        public async Task<IActionResult> OnGetAsync()
        {
            Debug = 0;
              await Lode();

            return Page();
        }

        private async Task Lode()
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            CanteenList = await _context.Canteen.Include(c => c.Company).Where( c=>c.Canteen_CompanyID == Employee.Employee_CompanyID).ToListAsync();
            select = CanteenList.FirstOrDefault(e => e.Status.Equals("Open"));
            CanteenList = CanteenList.Where(c => c.Status.Equals("Close") ).ToList();
        }

        [BindProperty]
        public Canteen Canteen { get; set; }

       



        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            Debug = 0;
            var check = 0;
            if (Canteen.Name == null)
            {
                check = 1;
                ModelState.AddModelError("Canteen.Name", "The NameCar field is required.");
            }
            if (Canteen.Email == null)
            {
                check = 1;
                ModelState.AddModelError("Canteen.Email", "The Seat field is required.");
            }
            if (Canteen.Line == null)
            {
                check = 1;
                ModelState.AddModelError("Canteen.Line", "The Line field is required.");
            }
            if (Canteen.Call == null)
            {
                check = 1;
                ModelState.AddModelError("Canteen.Call", "The Call field is required.");
            }

            if (check == 1)
            {
                Debug = 1;
                await Lode();
                return Page();
            }





           
            
            _context.Canteen.Add(Canteen);
            await _context.SaveChangesAsync();

            var foodset = new FoodSet();
            foodset.FoodSetcoManul = "No";
            foodset.NameSet = "No";
            foodset.Price = 0;
            foodset.Status = "Open";
            foodset.Canteen_CanteenID = Canteen.CanteenID;

            _context.FoodSet.Add(foodset);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ManageCanteen");
        }


        [BindProperty]
        public Canteen CanteenEdit { get; set; }

        public async Task<IActionResult> OnPostEditAsync()
        {


            Debug = 0;
            var check = 0;
            if (CanteenEdit.Name == null)
            {
                check = 1;
                ModelState.AddModelError("CanteenEdit.Name", "The NameCar field is required.");
            }
            if (CanteenEdit.Email == null)
            {
                check = 1;
                ModelState.AddModelError("CanteenEdit.Email", "The Seat field is required.");
            }
            if (CanteenEdit.Line == null)
            {
                check = 1;
                ModelState.AddModelError("CanteenEdit.Line", "The Line field is required.");
            }
            if (CanteenEdit.Call == null)
            {
                check = 1;
                ModelState.AddModelError("CanteenEdit.Call", "The Call field is required.");
            }

            if (check == 1)
            {
                Debug = 2;
                await Lode();
                return Page();
            }


           

            _context.Attach(CanteenEdit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CanteenExists(CanteenEdit.CanteenID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            await Lode();
            return RedirectToPage("./ManageCanteen");
        }

        private bool CanteenExists(int id)
        {
            return _context.Canteen.Any(e => e.CanteenID == id);
        }













        public async Task<IActionResult> OnPostSelectAsync(int id)
        {
           
            var set = await _context.Canteen.FirstOrDefaultAsync(e => e.CanteenID == id);
            var defail = await _context.Canteen.FirstOrDefaultAsync(e => e.Canteen_CompanyID == set.Canteen_CompanyID && e.Status.Equals("Open"));
            set.Status = "Open";
           
            _context.Attach(set).State = EntityState.Modified;

           

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CanteenExists(set.CanteenID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            defail.Status = "Close";
            _context.Attach(defail).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CanteenExists(defail.CanteenID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            await Lode();
            return RedirectToPage("./ManageCanteen");
        }

        


    }
}
