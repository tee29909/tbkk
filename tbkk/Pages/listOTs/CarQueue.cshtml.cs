using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.listOTs
{
    public class CarQueueModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public CarQueueModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        public IList<DetailCarQueue> DetailCarQueue { get; set; }

        public Employee Employee { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {


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
            DetailCarQueue = await _context.DetailCarQueue
                .Include(d => d.Employee)
                .Include(d => d.CarQueue.Part)
                .Include(d => d.CarQueue.CarType)
                .Where(e => e.DetailCarQueue_EmployeeID == Employee.EmployeeID)
                .ToListAsync();
            return Page();
        }
    }
}
