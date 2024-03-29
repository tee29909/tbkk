﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using tbkk.Models;

namespace tbkk.Pages.CarTypes
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
            ViewData["CarType_CompanyCarID"] = new SelectList(_context.CompanyCar, "CompanyCarID", "CompanyCarID");
            return Page();
        }

        [BindProperty]
        public CarType CarType { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Employee = HttpContext.Session.GetLogin(_context.Employee);
                return Page();
            }
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            _context.CarType.Add(CarType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
