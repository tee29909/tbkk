using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk.Pages.listOTs
{
    public class ConfirmShuttleModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public ConfirmShuttleModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        public IList<DetailOT> DetailOT { get;set; }
        public OT OT { get; set; }
        public Employee Employee { get; set; }

       

        public async Task<IActionResult> OnGetAsync(int? id, int? Did)
        {

            if (id == null)
            {
                return NotFound();
            }

            await onLoad(id, Did);
            if (OT == null)
            {
                return NotFound();
            }


            if (Employee == null)
            {
                return NotFound();
            }

            return Page();
        }

        private async Task onLoad(int? id, int? Did)
        {
            Employee = await _context.Employee
             .Include(e => e.Company)
             .Include(e => e.Department)
             .Include(e => e.EmployeeType)
             .Include(e => e.Location)
             .Include(e => e.Position).FirstOrDefaultAsync(m => m.EmployeeID == id);
            OT = await _context.OT.FirstOrDefaultAsync(m => m.OTID == Did);
            DetailOT = await _context.DetailOT
                
                .Include(d => d.Employee)
                .Include(d => d.FoodSet)
                .Include(d => d.OT)
                .Include(d => d.Part).ToListAsync();

        }
    }
}
