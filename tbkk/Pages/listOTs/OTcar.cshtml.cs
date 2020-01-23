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
    public class OTcarModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public OTcarModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; }
        public IList<OT> OT { get;set; }
        public detailList detailList { get; set; }
        public async Task OnGetAsync(int? id)
        {
            string TypStatus = "Close";
            OT = await _context.OT.ToListAsync();
            OT = OT.Where(o => o.TypStatus.Equals(TypStatus)&& o.date.Year ==2019 && o.date.Month == 1).ToList();
            foreach (var item in OT)
            {
                detailList.OT = detailList.OT + _context.DetailOT.Where(o => o.OT_OTID==item.OTID && o.Status.Equals("Allow")).ToList().Count;
                detailList.car = detailList.car + _context.CarQueue.Where(o => o.CarQueue_OTID == item.OTID).ToList().Count;
                detailList.food = detailList.OT + _context.DetailOT.Where(o => o.OT_OTID == item.OTID && o.Status.Equals("Allow") &&(o.TimeStart.Hour ==8|| o.TimeStart.Hour == 17) && !o.FoodSet.NameSet.Equals("No")).ToList().Count;


                detailList.total = detailList.OT + _context.DetailOT.Where(o => o.OT_OTID == item.OTID && o.Status.Equals("Allow") && (o.TimeStart.Hour == 8 || o.TimeStart.Hour == 17) && !o.FoodSet.NameSet.Equals("No")).ToList().Count;
            }






            Employee = await _context.Employee
                .Include(e => e.Company)
                .Include(e => e.Department)
                .Include(e => e.EmployeeType)
                .Include(e => e.Location)
                .Include(e => e.Position).FirstOrDefaultAsync(m => m.EmployeeID == id);

        }
    }

    public class detailList
    {
        public int OT { get; set; }
        public int car { get; set; }
        public int food { get; set; }
        public int total { get; set; }
    }
}
