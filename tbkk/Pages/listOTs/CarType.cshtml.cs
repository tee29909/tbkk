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
    public class CarTypeModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public CarTypeModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        public IList<CarType> CarTypeList { get; set; }

        public Employee Employee { get; set; }
        public CompanyCar CompanyCar { get; set; }
        public int Debug { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Debug = 0;
            await OnLode(id);

            return Page();
        }

        private async Task OnLode(int id)
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            CarTypeList = await _context.CarType
                .Include(c => c.CompanyCar).Where(e => e.CarType_CompanyCarID == id).ToListAsync();
            CompanyCar = await _context.CompanyCar.FirstOrDefaultAsync(e => e.CompanyCarID == id);
        }

        [BindProperty]
        public CarType CarType { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            Debug = 0;
            var check = 0;
            if (CarType.NameCar == null)
            {
                check = 1;
                ModelState.AddModelError("CarType.NameCar", "The NameCar field is required.");
            }
            if (CarType.Seat == 0)
            {
                check = 1;
                ModelState.AddModelError("CarType.Seat", "The Seat field is required.");
            }
          
            if (check == 1)
            {
                Debug = 1;
                await OnLode(CarType.CarType_CompanyCarID);
                return Page();
            }

           

            _context.CarType.Add(CarType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./CarType",new { id = CarType.CarType_CompanyCarID });
        }
        [BindProperty]
        public CarType CarTypeEdit { get; set; }
        public async Task<IActionResult> OnPostEditAsync()
        {


            Debug = 0;
            var check = 0;
            if (CarTypeEdit.NameCar == null)
            {
                check = 1;
                ModelState.AddModelError("CarTypeEdit.NameCar", "The NameCar field is required.");
            }
            if (CarTypeEdit.Seat == 0)
            {
                check = 1;
                ModelState.AddModelError("CarTypeEdit.Seat", "The Seat field is required.");
            }

            if (check == 1)
            {
                Debug = 2;
                await OnLode(CarTypeEdit.CarType_CompanyCarID);
                return Page();
            }
            

            _context.Attach(CarTypeEdit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarTypeExists(CarTypeEdit.CarTypeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./CarType", new { id = CarTypeEdit.CarType_CompanyCarID });
        }











        public async Task<IActionResult> OnPostCloseAsync(int id)
        {

            var Close = await _context.CarType.FirstOrDefaultAsync(e => e.CarTypeID == id);
            Close.Status = "Close";
            _context.Attach(Close).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarTypeExists(Close.CarTypeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./CarType", new { id = Close.CarType_CompanyCarID });
        }


        public async Task<IActionResult> OnPostOpenAsync(int id)
        {

            var Open = await _context.CarType.FirstOrDefaultAsync(e => e.CarTypeID == id);
            Open.Status = "Open";
            _context.Attach(Open).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarTypeExists(Open.CarTypeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./CarType", new { id = Open.CarType_CompanyCarID });
        }


















        private bool CarTypeExists(int id)
        {
            return _context.CarType.Any(e => e.CarTypeID == id);
        }
    }
}
