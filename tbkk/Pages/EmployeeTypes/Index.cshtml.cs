using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.EmployeeTypes
{
    public class IndexModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public IndexModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        public IList<EmployeeType> EmployeeType { get;set; }

        public async Task OnGetAsync()
        {
            EmployeeType = await _context.EmployeeType.ToListAsync();
        }
    }
}
