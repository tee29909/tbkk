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
            var part = _context.Part.ToList();
            var detailListAdd = new detailList();
            detailListAdd.OT = 0;
            detailListAdd.car = 0;
            detailListAdd.food = 0;
            detailListAdd.total = 0;
            foreach (var item in OT) 
            {
                var carq = _context.CarQueue.Where(c => c.CarQueue_OTID == item.OTID).ToList();
                var DetailOT = _context.DetailOT.Where(o => o.OT_OTID == item.OTID && o.Status.Equals("Allow")).Include(d => d.Employee)
                .Include(d => d.FoodSet)
                .Include(d => d.OT)
                .Include(d => d.Part).ToList();
                detailListAdd.OT = detailListAdd.OT + DetailOT.Count;
                detailListAdd.car = detailListAdd.car + _context.CarQueue.Where(o => o.CarQueue_OTID == item.OTID).ToList().Count;
                var food = DetailOT.Where(o => (o.TimeStart.Hour == 8 || o.TimeStart.Hour == 17) && !o.FoodSet.NameSet.Equals("No")).ToList();
                detailListAdd.food = detailListAdd.food + food.Count;
                //int totalCar = 0;
                //foreach (var p in part)
                //{

                //    totalCar = totalCar + (carq.Where(c => c.CarQueue_PartID == p.PartID).ToList().Count * p.Price);
                //}
                detailListAdd.total = detailListAdd.total + carq.Sum(t => t.Part.Price)+ food.Sum(t => t.FoodSet.Price);
            }
            detailList = detailListAdd;







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
