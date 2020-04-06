﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.listOTs
{
    public class manageOTModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public manageOTModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        public Employee Employee { get; set; }
        public IList<OT> OT { get;set; }

        public IList<OT> OTa { get; set; }

        public OT OTs { get; set; }

        public CompanyCar CompanyCar { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            OT = await _context.OT.Where(e => e.TypStatus.Equals("Close")).ToListAsync();
            OTa = await _context.OT.Where(e => e.TypStatus.Equals("Open") || e.TypStatus.Equals("Manage Car")).ToListAsync();
           
            try
            {
                Employee = HttpContext.Session.GetLogin(_context.Employee);
            }
            catch (Exception)
            {
                return RedirectToPage("./index");
            }
            if (Employee == null)
            {
                return NotFound();
            }
            var CompanyCarList = await _context.CompanyCar.Where(e => e.Company_CompanyID == Employee.Company_CompanyID).ToListAsync();
            CompanyCar = CompanyCarList.FirstOrDefault(e => e.Status.Equals("Open"));
            return Page();
        }



        public async Task<IActionResult> OnPostAsync(int? Did)
        {
            
            OTs = await _context.OT.FirstOrDefaultAsync(o => o.OTID == Did);
            OTs.TypStatus = "Manage Car";
            _context.Attach(OTs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OTExists(OTs.OTID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./../listOTs/ConfirmShuttle", new { Did = Did });
        }
        private bool OTExists(int id)
        {
            return _context.OT.Any(e => e.OTID == id);
        }
    }
}
