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
    public class IndexModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public IndexModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        public IList<CarQueue> CarQueue { get;set; }
 public Employee Employee { get; set; }
        public async Task OnGetAsync()
        {
            
        Employee = HttpContext.Session.GetLogin(_context.Employee);
            CarQueue = await _context.CarQueue
                .Include(c => c.CarType)
                .Include(c => c.OT)
                .Include(c => c.Part).ToListAsync();
        }
    }
}
