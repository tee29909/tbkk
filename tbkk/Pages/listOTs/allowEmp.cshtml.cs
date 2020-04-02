﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.listOTs
{
    public class allowEmpModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public allowEmpModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        public IList<DetailOT>  DetailOT { get; set; }
        public Employee Employee { get; set; }
        
        public OT OT { get; set; }



        public async Task<IActionResult> OnGetAsync(int id)
        {
            
            

            try
            {
                await OnLoad(id);
            }
            catch (Exception)
            {
                return RedirectToPage("./index");
            }
            

            

            if (DetailOT == null)
            {
                return NotFound();
            }
            
            return Page();
        }



        public async Task<IActionResult> OnPostRemoveAsync(int id)
        {
            
            var DetailOTs = await _context.DetailOT
               .FirstOrDefaultAsync(e => e.DetailOTID == id);
            DetailOTs.Status = "Disallow";
            _context.Attach(DetailOTs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailOTExists(DetailOTs.DetailOTID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            try
            {
                await OnLoad(DetailOTs.OT_OTID);
                

            }
            catch (Exception)
            {
                return RedirectToPage("./index");
            }

          

            return Page();
        }

        public async Task<IActionResult> OnPostAllowAsync(int id)
        {

            var DetailOTs = await _context.DetailOT
               .FirstOrDefaultAsync(e => e.DetailOTID == id);
            DetailOTs.Status = "Allow";
            _context.Attach(DetailOTs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailOTExists(DetailOTs.DetailOTID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            try
            {
                await OnLoad(DetailOTs.OT_OTID);

            }
            catch (Exception)
            {
                return RedirectToPage("./index");
            }

            

            return Page();
        }






        public async Task<IActionResult> OnPostAddAllowedAsync(int id)
        {

            try
            {
                await OnLoad(id);
            }
            catch (Exception)
            {
                return RedirectToPage("./index");
            }

            var newDetailOTs = await _context.DetailOT.Include(d => d.Employee).Where(n => n.OT_OTID == id && n.Employee.Employee_DepartmentID == Employee.Employee_DepartmentID).ToArrayAsync();
            
            foreach (var item in newDetailOTs)
            {
                DetailOT newDetailOT = item;
                newDetailOT.Status = "Allow";

                _context.Attach(newDetailOT).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailOTExists(newDetailOT.DetailOTID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }



            return Page();
        }




        public async Task<IActionResult> OnPostAddDisallowAsync(int id)
        {

            try
            {
                 await OnLoad(id);
            }
            catch (Exception)
            {
                return RedirectToPage("./index");
            }

            var newDetailOTs = await _context.DetailOT.Include(d => d.Employee).Where(n => n.OT_OTID == id && n.Employee.Employee_DepartmentID == Employee.Employee_DepartmentID && n.Status.Equals("Pending for approval")).ToArrayAsync();

            foreach (var item in newDetailOTs)
            {
                DetailOT newDetailOT = item;
                newDetailOT.Status = "Disallow";

                _context.Attach(newDetailOT).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailOTExists(newDetailOT.DetailOTID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }



            return Page();
        }




        private async Task OnLoad(int id)
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            DetailOT = await _context.DetailOT
            .Include(d => d.Employee)
            .Include(d => d.FoodSet)
            .Include(d => d.OT)
            .Include(d => d.Point.Part).Where(d => d.OT_OTID == id).ToListAsync();
            DetailOT = DetailOT.Where(d => d.Employee.Employee_DepartmentID == Employee.Employee_DepartmentID).ToList();
            OT = await _context.OT
              .FirstOrDefaultAsync(e => e.OTID == id);

        }





        private bool DetailOTExists(int id)
        {
            return _context.DetailOT.Any(e => e.DetailOTID == id);
        }
    }
}
