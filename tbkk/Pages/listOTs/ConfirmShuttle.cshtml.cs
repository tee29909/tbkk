using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;
using Newtonsoft.Json;
using System.Diagnostics;

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



       


        public string json { get; set; }





       
        public IList<FoodSet> FoodSet { get; set; }


        [BindProperty]
        public IList<CarsPart> Round_8 { get; set; }
        [BindProperty]
        public IList<CarsPart> Round_17 { get; set; }
        [BindProperty]
        public IList<CarsPart> Round_20 { get; set; }




        public IList<Part> Part { get; set; }
        public IList<DetailOT> DetailOTnew { get; set; }
        public IList<Department> Department { get; set; }
        public IList<CarType> CarType { get; set; }
        public OTs OTs { get; set; }
        public IList<Depasments> Depasments { get; set; }
        public IList<Cars> Cars { get; set; }
        

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

            
            OTs = ListOTDetail(Did);


            
            Depasments = OTDetailOTList();
            IList<DetailOT> mDetailOTnew;
            if (OT.TypeOT.Equals("Saturday")&& OT.TypeOT.Equals("Sunday"))
            {
                mDetailOTnew = DetailOT.Where(d => (d.Type.Equals("Go") || d.Type.Equals("Go and Back"))&& d.TimeStart.Hour==8 && d.TimeStart.Minute == 0).ToList();
                Round_8 = ManageCar(mDetailOTnew);
                mDetailOTnew = DetailOT.Where(d => (d.Type.Equals("Back") || d.Type.Equals("Go and Back")) && d.TimeEnd.Hour == 17 && d.TimeEnd.Minute == 0).ToList();
                Round_17 = ManageCar(mDetailOTnew);
                mDetailOTnew = DetailOT.Where(d => (d.Type.Equals("Back") || d.Type.Equals("Go and Back")) && d.TimeEnd.Hour == 20 && d.TimeEnd.Minute == 0).ToList();
                Round_20 = ManageCar(mDetailOTnew);
            }
            else
            {
                mDetailOTnew = DetailOT.Where(d => d.Type.Equals("Back") && d.TimeEnd.Hour == 20 && d.TimeEnd.Minute == 0).ToList();
                Round_20 = ManageCar(mDetailOTnew);
            }
            
            return Page();
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

        private List<CarsPart> ManageCar(IList<DetailOT> mDetailOTnew)
        {
            List<CarsPart> CarsParts = new List<CarsPart>();

            foreach (var i in Part)
            {
                CarsPart CarsPartNew = new CarsPart();
                CarsPartNew.PartID = i.PartID;
                CarsPartNew.namePart = i.Name;
                
                List<Cars> CarsNew = new List<Cars>();
               
                CarsPartNew.DetailOT = mDetailOTnew.Where(c => c.Part_PaetID == i.PartID).ToList();
                int count = mDetailOTnew.Where(c => c.Part_PaetID == i.PartID).ToList().Count;
                
                foreach (var j in CarType)
                {
                    if (j.Seat <= count)
                    {
                        Cars cars = new Cars();
                        cars.CarTypeID = j.CarTypeID;
                        cars.CarTypeName = j.NameCar;
                        cars.seed = j.Seat;



                        if (j.Seat != 0)
                        {
                            int add = count / j.Seat;
                            count = count % j.Seat;
                            cars.countCar = add;
                            CarsNew.Add(cars);
                        }
                    }
                }
                Cars min = new Cars();
                int seedMon = 9999;
                foreach (var j in CarType)
                {
                    if (j.Seat != 0)
                    {
                        if (j.Seat < seedMon)
                        {
                            seedMon = j.Seat;
                            min.CarTypeID = j.CarTypeID;
                            min.CarTypeName = j.NameCar;
                            min.seed = j.Seat;
                            min.countCar = 1;
                            
                        }
                    }
                }

                if (count > 0)
                {
                    int check = 0;
                    foreach (var j in CarsNew)
                    {
                        if (j.CarTypeID == min.CarTypeID)
                        {
                            check = +1;
                            j.countCar = j.countCar + 1;
                            break;
                        }
                    }
                    if (check == 0)
                    {
                        CarsNew.Add(min);
                    }

                }


                CarsPartNew.ListCars = CarsNew;
                if (DetailOTnew.Where(d => d.Part_PaetID == i.PartID).ToList().Count != 0)
                {
                    CarsParts.Add(CarsPartNew);
                }
            }

            return CarsParts;
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
            FoodSet =await _context.FoodSet.ToListAsync();
            CarType = await _context.CarType.ToListAsync();
            CarType = CarType.OrderByDescending(o => o.Seat).ToList();






        }



        public string foodToken = "gpLcFbnpq8RcdSP67A4vFdZMKlfz9vBDlI0IVB2TsXV";
        public string carToken = "YGWdtLg5mavVWPlBmU0CT2WcZspAguWgZljx7FXBIEk";

        public async Task OnPostLineAsync(int id,int Did)
        {
            Line l = new Line();
            
            //food
            l.lineNotify("test food", foodToken);
            l.notifySticker("อาหารมาแล้ว",150,2, foodToken);
            //car
            l.lineNotify("test car", carToken);
            l.notifySticker("รถมาแล้ว", 160, 2, carToken);
            await onLoad(id, Did);
            //FromDataManage(Did);
        }

        public async Task<ActionResult> OnPostAsync(int id,int Did)
        {
            OT = await _context.OT.FirstOrDefaultAsync(m => m.OTID == Did);
            if (Round_20.Any())
            {
                foreach (var item in Round_20)
                {
                    int index = Round_20.IndexOf(item);
                    Debug.WriteLine("มาแล้ว " + Round_20[index].PartID);
                    Debug.WriteLine("มาแล้ว " + Round_20[index].namePart);
                    foreach (var j in item.ListCars)
                    {
                        int index2 = Round_20[index].ListCars.IndexOf(j);
                        CarQueue createCarQueue = new CarQueue();
                        int Emp = 0;
                        for (int i =1;i<= Round_20[index].ListCars[index2].countCar;i++)
                        {
                            createCarQueue.CarNumber = i;
                            createCarQueue.Type = "Back";
                            createCarQueue.CarQueue_OTID = Did;
                            createCarQueue.Time = new DateTime(OT.date.Year, OT.date.Month, OT.date.Day,20,0,0);
                            createCarQueue.CarQueue_PartID = item.PartID;
                            createCarQueue.CarQueue_CarTypeID = j.CarTypeID;


                            _context.CarQueue.Add(createCarQueue);
                            int returnID = await _context.SaveChangesAsync();
                            Debug.WriteLine("มาดิครับ555 "+ j.seed);


                            for (int q = 1; q <= j.seed; q++)
                            {
                                if (Emp == item.DetailOT.Count)
                                {
                                    break;
                                }

                                Debug.WriteLine("มาดิครับ555");
                                DetailCarQueue createDetailCarQueue = new DetailCarQueue();
                                createDetailCarQueue.DetailCarQueue_EmployeeID = item.DetailOT[Emp].Employee_EmpID;
                                createDetailCarQueue.DetailCarQueue_CarQueueID = returnID;
                                _context.DetailCarQueue.Add(createDetailCarQueue);
                                await _context.SaveChangesAsync();
                                Emp = Emp + 1;
                            }
                            Debug.WriteLine("มาแล้ว สินะ" + item.DetailOT.Count);
                        }
                        
                        Debug.WriteLine("มาแล้ว " + Round_20[index].ListCars[index2].CarTypeID);
                        Debug.WriteLine("มาแล้ว " + Round_20[index].ListCars[index2].CarTypeName);
                        Debug.WriteLine("มาแล้ว " + Round_20[index].ListCars[index2].countCar);
                    }
                }
                
            }
            else
            {
                Debug.WriteLine("Round_20 Null");
            }

            if (Round_8.Any())
            {
                foreach (var item in Round_8)
                {
                    int index = Round_8.IndexOf(item);
                    Debug.WriteLine("มาแล้ว " + Round_8[index].PartID);
                    Debug.WriteLine("มาแล้ว " + Round_8[index].namePart);
                    foreach (var j in item.ListCars)
                    {
                        int index2 = Round_8[index].ListCars.IndexOf(j);
                        Debug.WriteLine("มาแล้ว " + Round_8[index].ListCars[index2].CarTypeID);
                        Debug.WriteLine("มาแล้ว " + Round_8[index].ListCars[index2].CarTypeName);
                        Debug.WriteLine("มาแล้ว " + Round_8[index].ListCars[index2].countCar);
                    }
                }

            }
            else
            {
                Debug.WriteLine("Round_8 Null");
            }


            if (Round_17.Any())
            {
                foreach (var item in Round_17)
                {
                    int index = Round_17.IndexOf(item);
                    Debug.WriteLine("มาแล้ว " + Round_17[index].PartID);
                    Debug.WriteLine("มาแล้ว " + Round_17[index].namePart);
                    foreach (var j in item.ListCars)
                    {
                        int index2 = Round_17[index].ListCars.IndexOf(j);
                        Debug.WriteLine("มาแล้ว " + Round_17[index].ListCars[index2].CarTypeID);
                        Debug.WriteLine("มาแล้ว " + Round_17[index].ListCars[index2].CarTypeName);
                        Debug.WriteLine("มาแล้ว " + Round_17[index].ListCars[index2].countCar);
                    }
                }

            }
            else
            {
                Debug.WriteLine("Round_17 Null");
            }

            //_context.CarsPart.Add(Round_8);


            //Your logic here using Products and statusId 
            return Page();
        }


    }

}
