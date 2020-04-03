using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.CarQueues
{
    public class DetailsModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public DetailsModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        public CarQueue CarQueue { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarQueue = await _context.CarQueue
                .Include(c => c.CarType)
                .Include(c => c.OT)
                .Include(c => c.Part).FirstOrDefaultAsync(m => m.CarQueueID == id);

            if (CarQueue == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
