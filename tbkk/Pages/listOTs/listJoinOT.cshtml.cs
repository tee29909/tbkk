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
    public class listJoinOTModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;
          
        public listJoinOTModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; }
        
        public IList<DetailOT> DetailOT { get;set; }

        public TimeSpan countHourOT { get; set; }







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

            

            DetailOT = await _context.DetailOT
                
                .Include(d => d.Employee)
                .Include(d => d.FoodSet)
                .Include(d => d.OT)
                .Include(d => d.Point.Part).Where(d => d.Employee_EmpID == Employee.EmployeeID && d.Status.Equals("Allow")).ToListAsync();

           
            
            countHourOT = new TimeSpan();
            foreach (var item in DetailOT)
            {
                countHourOT = countHourOT + item.Hour;
            }

            

            

           
            return Page();
        }
    }
}
