﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.Canteens
{
    public class DetailsModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public DetailsModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
public Employee Employee { get; set; }
        public Canteen Canteen { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
             
        Employee = HttpContext.Session.GetLogin(_context.Employee);
            Canteen = await _context.Canteen
                .Include(c => c.Company).FirstOrDefaultAsync(m => m.CanteenID == id);

            if (Canteen == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
