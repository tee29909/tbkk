using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.DetailCarQueues
{
    public class DetailsModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public DetailsModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        public Employee Employee { get; set; }
        public DetailCarQueue DetailCarQueue { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            if (id == null)
            {
                return NotFound();
            }

            DetailCarQueue = await _context.DetailCarQueue
                .Include(d => d.CarQueue)
                .Include(d => d.Employee).FirstOrDefaultAsync(m => m.DetailCarQueueID == id);

            if (DetailCarQueue == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
