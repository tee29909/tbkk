﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.test
{
    public class testModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public testModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        public IList<OT> OT { get;set; }

        public async Task OnGetAsync()
        {
            OT = await _context.OT.ToListAsync();
        }
    }
}