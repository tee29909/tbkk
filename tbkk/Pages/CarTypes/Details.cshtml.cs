using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.CarTypes
{
    public class DetailsModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public DetailsModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        public CarType CarType { get; set; }
        public Employee Employee { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            CarType = await _context.CarType
                .Include(c => c.CompanyCar).FirstOrDefaultAsync(m => m.CarTypeID == id);

            if (CarType == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
