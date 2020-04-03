using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.Points
{
    public class DetailsModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public DetailsModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        public Point Point { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Point = await _context.Point
                .Include(p => p.Part).FirstOrDefaultAsync(m => m.PointID == id);

            if (Point == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
