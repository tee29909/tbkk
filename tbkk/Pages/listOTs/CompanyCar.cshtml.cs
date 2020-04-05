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
    public class CompanyCarModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public CompanyCarModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        public IList<CompanyCar> CompanyCarList { get; set; }
        public CompanyCar select { get; set; }
        public Employee Employee { get; set; }

        public int Debug { get; set; }



        public async Task<IActionResult> OnGetAsync()
        {
            Debug = 0;
            await OnLode();

            return Page();
        }

        private async Task OnLode()
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);

            CompanyCarList = await _context.CompanyCar
               .Include(c => c.Company).Where(e => e.Company_CompanyID == Employee.Employee_CompanyID).ToListAsync();
            select = new CompanyCar();
            select = CompanyCarList.FirstOrDefault(e => e.Status.Equals("Open"));
            CompanyCarList = CompanyCarList.Where(e => e.Status.Equals("Close")).ToList();
        }

        [BindProperty]
        public CompanyCar CompanyCar { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Debug = 0;
            var check = 0;
            if (CompanyCar.NameCompanyCar == null)
            {
                check = 1;
                ModelState.AddModelError("CompanyCar.NameCompanyCar", "The NameCompanyCar field is required.");
            }
            if (CompanyCar.Email == null)
            {
                check = 1;
                ModelState.AddModelError("CompanyCar.Email", "The Email field is required.");
            }
            if (CompanyCar.Call == null)
            {
                check = 1;
                ModelState.AddModelError("CompanyCar.Call", "The Call field is required.");
            }
            if (CompanyCar.Line == null)
            {
                check = 1;
                ModelState.AddModelError("CompanyCar.Line", "The Line field is required.");
            }
            if(check == 1)
            {
                Debug = 1;
                await OnLode();
                return Page();
            }



           

            _context.CompanyCar.Add(CompanyCar);
            await _context.SaveChangesAsync();

            return RedirectToPage("./CompanyCar");
        }
        [BindProperty]
        public CompanyCar CompanyCarEdit { get; set; }


        public async Task<IActionResult> OnPostEditAsync()
        {
            Debug = 0;
            var check = 0;
            if (CompanyCarEdit.NameCompanyCar == null)
            {
                check = 1;
                ModelState.AddModelError("CompanyCarEdit.NameCompanyCar", "The NameCompanyCar field is required.");
            }
            if (CompanyCarEdit.Email == null)
            {
                check = 1;
                ModelState.AddModelError("CompanyCarEdit.Email", "The Email field is required.");
            }
            if (CompanyCarEdit.Call == null)
            {
                check = 1;
                ModelState.AddModelError("CompanyCarEdit.Call", "The Call field is required.");
            }
            if (CompanyCarEdit.Line == null)
            {
                check = 1;
                ModelState.AddModelError("CompanyCarEdit.Line", "The Line field is required.");
            }
            if (check == 1)
            {
                Debug = 2;
                await OnLode();
                return Page();
            }

            _context.Attach(CompanyCarEdit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyCarExists(CompanyCarEdit.CompanyCarID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./CompanyCar");
        }
        public async Task<IActionResult> OnPostSelectAsync(int id)
        {

            var set = await _context.CompanyCar.FirstOrDefaultAsync(e => e.CompanyCarID == id);
            var defail = await _context.CompanyCar.FirstOrDefaultAsync(e => e.Company_CompanyID == set.Company_CompanyID && e.Status.Equals("Open"));
            set.Status = "Open";

            _context.Attach(set).State = EntityState.Modified;



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyCarExists(set.CompanyCarID))
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
                if (!CompanyCarExists(defail.CompanyCarID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("./CompanyCar");
        }

        private bool CompanyCarExists(int id)
        {
            return _context.CompanyCar.Any(e => e.CompanyCarID == id);
        }
    }
}
