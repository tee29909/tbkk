using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;

namespace tbkk
{
    public class ContactCarFoodModel : PageModel
    {
        private readonly tbkk.Models.tbkkdbContext _context;

        public ContactCarFoodModel(tbkk.Models.tbkkdbContext context)
        {
            _context = context;
        }
        public IList<DetailOT> DetailOTnew { get; set; }
        public IList<FoodSet> FoodSet { get; set; }
        public IList<Part> Part { get; set; }
        public IList<CarType> CarType { get; set; }
        public IList<DetailOT> DetailOT { get; set; }
        public IList<Department> Department { get; set; }
        public Employee Employee { get; set; }
        public IList<Depasments> Depasments { get; set; }
        public IList<CarQueue> CarQueue { get; set; }
        public IList<DetailCarQueue> DetailCarQueue { get; set; }
        public OTs OTs { get; set; }
        public OT OT { get; set; }

        public string mass { get; set; }



        public string foodToken = "gpLcFbnpq8RcdSP67A4vFdZMKlfz9vBDlI0IVB2TsXV";
        public string carToken = "YGWdtLg5mavVWPlBmU0CT2WcZspAguWgZljx7FXBIEk";

        public async Task OnPostLineAsync(int id, int Did)
        {
            Line l = new Line();

            //food
            l.lineNotify(mass, foodToken);
            l.notifySticker(mass, 150, 2, foodToken);
            //car
            l.lineNotify(mass, carToken);
            l.notifySticker(mass, 160, 2, carToken);
            
            //FromDataManage(Did);
        }



        public IList<CatList> CatList { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id ,int? Did)
        {
            if (id == null)
            {
                return NotFound();
            }


            await onLoad(id, Did);



            OTs = ListOTDetail(Did);
            Depasments = OTDetailOTList();
            CatList = DetailPartCarEmp();















            if (OT == null)
            {
                return NotFound();
            }
            return Page();
        }

        private List<CatList> DetailPartCarEmp()
        {
            List<CatList> addcatListsArr = new List<CatList>();
            foreach (var item in Part)
            {
                if (!item.Name.Equals("No"))
                {
                    var list = DetailCarQueue.Where(l => l.CarQueue.CarQueue_PartID == item.PartID).ToList();

                    if (list.Count != 0)
                    {
                        CatList addcatList = new CatList();
                        List<carListNumber> carListNumberlist = new List<carListNumber>();

                        addcatList.Parts = item;
                        addcatList.DetailCarQueue = list;
                        foreach (var i in CarType)
                        {
                            carListNumber carListNumber = new carListNumber();

                            var CarTypePart = CarQueue.Where(c => c.CarQueue_CarTypeID == i.CarTypeID && c.CarQueue_PartID == item.PartID).ToList();
                            if (CarTypePart.Count != 0)
                            {
                                carListNumber.CarType = i;
                                carListNumber.maxCar = CarTypePart.Max(z => z.CarNumber);
                                carListNumberlist.Add(carListNumber);

                            }
                        }
                        addcatList.carListNumber = carListNumberlist;

                        addcatListsArr.Add(addcatList);
                    }

                }

            }

            return addcatListsArr;
        }

        private async Task onLoad(int? id, int? Did)
        {
            Department = await _context.Department.ToListAsync();
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
            Part = await _context.Part.ToListAsync();
            FoodSet = await _context.FoodSet.ToListAsync();
            CarType = await _context.CarType.ToListAsync();
            CarType = CarType.OrderByDescending(o => o.Seat).ToList();
            DetailCarQueue = await _context.DetailCarQueue
              .Include(e => e.CarQueue)
              .Include(e => e.Employee)
              .Where(c => c.CarQueue.CarQueue_OTID == Did).ToListAsync();
            CarQueue = await _context.CarQueue
                .Include(e => e.OT)
                .Include(e => e.Part)
                .Include(e => e.CarType)
                .Where(c => c.CarQueue_OTID == Did).ToListAsync();
        }
        private List<Depasments> OTDetailOTList()
        {
            List<Depasments> add = new List<Depasments>();
            foreach (var i in Department)
            {
                Depasments DataDepasments = new Depasments();
                DataDepasments.DepasmentsName = i.DepartmentName;
                DataDepasments.DepasmentsID = i.DepartmentID;
                DataDepasments.DepasmentsCount = DetailOTnew.Where(d => d.Employee.Employee_DepartmentID == i.DepartmentID).ToList().Count;
                DataDepasments.CarCount = DetailOTnew.Where(d => !d.Type.Equals("No") && d.Employee.Employee_DepartmentID == i.DepartmentID).ToList().Count;
                DataDepasments.FoodCount = DetailOTnew.Where(d => d.FoodSet_FoodSetID != 1 && d.Employee.Employee_DepartmentID == i.DepartmentID).ToList().Count;
                List<Parts> Listparts = new List<Parts>();
                foreach (var j in Part)
                {
                    Parts parts = new Parts();
                    parts.PartID = j.PartID;
                    parts.PartName = j.Name;
                    IList<DetailOT> DataPart = DetailOTnew.Where(d => d.Part_PaetID != 1).ToList();
                    DataPart = DataPart.Where(d => d.Employee.Employee_DepartmentID == i.DepartmentID).ToList();
                    DataPart = DataPart.Where(d => d.Part_PaetID == j.PartID).ToList();
                    parts.PartsCount = DataPart.Where(d => !d.Type.Equals("No")).ToList().Count;
                    if (parts.PartsCount != 0)
                    {
                        Listparts.Add(parts);

                    }

                }
                DataDepasments.ListParts = Listparts;
                List<Foods> Listfoods = new List<Foods>();

                foreach (var j in FoodSet)
                {
                    Foods foods = new Foods();
                    foods.FoodID = j.FoodSetID;
                    foods.FoodName = j.NameSet;
                    IList<DetailOT> DataPart = DetailOTnew.Where(d => d.FoodSet_FoodSetID != 1).ToList();
                    DataPart = DataPart.Where(d => d.Employee.Employee_DepartmentID == i.DepartmentID).ToList();
                    DataPart = DataPart.Where(d => d.FoodSet_FoodSetID == j.FoodSetID).ToList();
                    foods.FoodsCount = DataPart.Where(d => !d.Type.Equals("No")).ToList().Count;
                    if (foods.FoodsCount != 0)
                    {
                        Listfoods.Add(foods); 
                    }

                }
                DataDepasments.ListFoods = Listfoods;
                add.Add(DataDepasments);
            }

            return add;
        }

        private OTs ListOTDetail(int? Did)
        {
            OTs OTsnew = new OTs();


            DetailOTnew = DetailOT.Where(d => d.OT_OTID == Did && d.Status.Equals("Allow")).ToList();
            OTsnew.countEmp = DetailOTnew.Count;

            foreach (var i in DetailOTnew)
            {
                if (i.FoodSet_FoodSetID != 1)
                {
                    OTsnew.countFood = OTsnew.countFood + 1;
                }
                if (!i.Type.Equals("No"))
                {
                    OTsnew.countCar = OTsnew.countCar + 1;
                }

            }

            return OTsnew;
        }
    }





    public class CatList
    {
        public Part Parts { get; set; }
        public IList<DetailCarQueue> DetailCarQueue { get; set; }
        public IList<carListNumber> carListNumber { get; set; }
    }
    public class carListNumber
    {
        public CarType CarType { get; set; }
        public int maxCar { get; set; }
    }


}
