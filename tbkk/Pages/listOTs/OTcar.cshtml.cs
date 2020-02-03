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
        public IList<chart1> chart1 { get; set; }
        public IList<chart2> chart2 { get; set; }
        public IList<chart3> chart3 { get; set; }
        public IList<chart4> chart4 { get; set; }
        public chart5 chart5 { get; set; }
        [BindProperty(SupportsGet = true)]
        public string search { get; set; }

        public detailList detailList { get; set; }
        public int Total { get; set; }
        public int TotalCar { get; set; }
        public int TotalFood { get; set; }
        public async Task OnGetAsync(int? id)
        {
            DateTime Mout;
            var t = search;
            if (!string.IsNullOrEmpty(search))
            {
                Mout = DateTime.Parse(t);
            }
            else
            {
                Mout = DateTime.Now;
            }
            
            int Month = Mout.Month;
            int Year = Mout.Year;
            var part = _context.Part.ToList();
            var Department = _context.Department.ToList();
            string TypStatus = "Close";
            OT = await _context.OT.ToListAsync();
            OT = OT.Where(o => o.TypStatus.Equals(TypStatus) && o.date.Year == Year && o.date.Month == Month).ToList();
            var detailOT = _context.DetailOT
                .Include(e => e.OT)
                .Include(e => e.Part)
                .Include(e => e.Employee)
                .Include(e => e.FoodSet).Where(d => d.OT.date.Year == Year && d.OT.date.Month == Month && d.Status.Equals("Allow")).ToList();
            var detailCarQ = _context.DetailCarQueue
                .Include(e => e.CarQueue)
                .Include(e => e.Employee).Where(d => d.CarQueue.OT.date.Year == Year && d.CarQueue.OT.date.Month == Month).ToList();




            detailList = detailListPage();
            chart1 = Chart1(Department, detailOT);

            
            chart3 = Chart3(part, detailCarQ);
            chart4 = Chart4();


            var Chart5 = new chart5();
            var total = new List<chart1>();
            var car = new List<chart1>();
            var food = new List<chart1>();

            for (var i = 1; i<=12;i++)
            {
                DateTime date = new DateTime(Year,i,1);
                var detailCar = _context.CarQueue.Where(c => c.OT.date.Year == Year && c.OT.date.Month == i).ToList();
                var detailadd = _context.DetailOT
                    .Include(e => e.OT)
                    .Include(e => e.Part)
                    .Include(e => e.Employee)
                    .Include(e => e.FoodSet).Where(d => d.OT.date.Year == Year && d.OT.date.Month == i && d.Status.Equals("Allow")).ToList();
                var costFoodAdd = detailadd.Where(o => (o.TimeStart.Hour == 8 || o.TimeStart.Hour == 17) && !o.FoodSet.NameSet.Equals("No")).ToList().Sum(s => s.FoodSet.Price);
                var costCarAdd = detailCar.Sum(s => s.Part.Price);
                total.Add(new chart1() { label = date.ToString("MMMM"), y = costCarAdd+costFoodAdd });
                car.Add(new chart1() { label = date.ToString("MMMM"), y = costCarAdd });
                food.Add(new chart1() { label= date.ToString("MMMM"),y= costFoodAdd });
            }

            Chart5.Total = total;
            Chart5.CostCar = car;
            Chart5.CostFood = food;

            chart5 = Chart5;







            //var detailOT = _context.DetailOT.OrderBy(i => i.DetailOTID).ToList();



            //Employee = await _context.Employee
            //    .Include(e => e.Company)
            //    .Include(e => e.Department)
            //    .Include(e => e.EmployeeType)
            //    .Include(e => e.Location)
            //    .Include(e => e.Position).FirstOrDefaultAsync(m => m.EmployeeID == id);
            Employee = HttpContext.Session.GetLogin(_context.Employee);

        }

        private static List<chart3> Chart3(List<Part> part, List<DetailCarQueue> detailCarQ)
        {
            var Chart3 = new List<chart3>();
            foreach (var item in part)
            {
                if (!item.Name.Equals("No"))
                {
                    var chart = new chart3() { y = detailCarQ.Where(y => y.CarQueue.CarQueue_PartID == item.PartID).Count(), label = item.Name };
                    Chart3.Add(chart);

                }
                
            }

            return Chart3;
        }

        private List<chart4> Chart4()
        {
            var chart4add = new List<chart4>();

            chart4add.Add(new chart4() { y = TotalCar, label = "Car" });
            chart4add.Add(new chart4() { y = TotalFood, label = "Food" });
            return chart4add;
        }

        private List<chart1> Chart1(List<Department> Department , List<DetailOT> DetailOT)
        {
            var listChart = new List<DetailOT>();
            foreach (var item in OT)
            {
                var detailOTAdd = DetailOT.Where(d => d.OT_OTID == item.OTID && d.Status.Equals("Allow")).ToList();
                listChart.AddRange(detailOTAdd);
            }

            var chart1List = new List<chart1>();

            foreach (var item in Department)
            {
                var char1add = new chart1();
                var dataDepartment = listChart.Where(c => c.Employee.Employee_DepartmentID == item.DepartmentID).ToList();
                char1add.y = dataDepartment.Sum(s => s.Hour.Hours);
                char1add.label = item.DepartmentName;
               
                chart1List.Add(char1add);
                
            }

            return chart1List;
        }

        private detailList detailListPage()
        {
            var detailListAdd = new detailList();
            detailListAdd.OT = 0;
            detailListAdd.car = 0;
            detailListAdd.food = 0;
            detailListAdd.total = 0;
            var costCar = 0;
            var costFood = 0;
            foreach (var item in OT)
            {
                var carq = _context.CarQueue.Where(c => c.CarQueue_OTID == item.OTID).ToList();
                var DetailOT = _context.DetailOT.Where(o => o.OT_OTID == item.OTID && o.Status.Equals("Allow"))
                    .Include(d => d.Employee)
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
                costCar = costCar + carq.Sum(t => t.Part.Price);
                costFood = costFood + food.Sum(t => t.FoodSet.Price);

                
            }
            detailListAdd.total = costCar + costFood;
            Total = detailListAdd.total;
            TotalCar = costCar;
            TotalFood = costFood;

            return detailListAdd;
        }
    }

    public class detailList
    {
        public int OT { get; set; }
        public int car { get; set; }
        public int food { get; set; }
        public int total { get; set; }
    }
    public class chart1
    {
        public int y { get; set; }
        public string label { get; set; }
       
    }
    public class chart2
    {
        public double y { get; set; }
        public string label { get; set; }

    }

    public class chart3
    {
        public int y { get; set; }
        public string label { get; set; }

    }
    public class chart4
    {
        public int y { get; set; }
        public string label { get; set; }

    }
    public class chart5
    {
        public List<chart1> Total { get; set; }
        public List<chart1> CostCar { get; set; }
        public List<chart1> CostFood { get; set; }
        
    }
}
