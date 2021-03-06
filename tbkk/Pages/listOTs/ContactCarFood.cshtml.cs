﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [BindProperty]
        public LineToken LineToken { get; set; }
        public OT OT { get; set; }

        public IList<food> food { get; set; }

        
        public IList<timelist> timelist { get; set; }

        

        //public string foodToken = "gpLcFbnpq8RcdSP67A4vFdZMKlfz9vBDlI0IVB2TsXV";
        //public string carToken = "YGWdtLg5mavVWPlBmU0CT2WcZspAguWgZljx7FXBIEk";







        public async Task OnPostLineAsync(int Did)
        {
            Line l = new Line();

            string massCar = Request.Form["massCar"];
            string massFood = Request.Form["massFood"];

            try
            {
                await onLoad(Did);
            }
            catch (Exception)
            {
                RedirectToPage("./index");
            }

            if (LineToken == null)
            {
                ModelState.AddModelError("Error", "Line Token is null.");

            }
            else
            {
                //food
                l.lineNotify(massFood, LineToken.TokenFood);
                //l.notifySticker("5564", 150, 2, foodToken);
                //car
                l.lineNotify(massCar, LineToken.TokenCar);
                //l.notifySticker("5564", 160, 2, carToken);
            }


           
            
            

            
            //FromDataManage(Did);
        }



        //public IList<CatList> CatList { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? Did)
        {



            try
            {
                await onLoad(Did);
            }
            catch (Exception)
            {
                return RedirectToPage("./index");
            }


            if (OT == null)
            {
                return NotFound();
            }
            return Page();
        }

        private List<food> foodMass()
        {
            var foodAdd = new List<food>();

            for (int i = 0; i < 2; i++)
            {
                var Addfood = new food();

                int timeCheck = 0;
                if (i == 0)
                {
                    timeCheck = 8;
                }
                else
                {
                    timeCheck = 17;
                }
                var foodlist = new List<foodList>();
                foreach (var item in FoodSet)
                {
                    
                        var add = new foodList();
                        if (timeCheck == 8)
                        {
                            add.list = DetailOTnew.Where(c => (c.TimeStart.Hour == timeCheck && c.TimeStart.Minute == 0) && c.FoodSet_FoodSetID == item.FoodSetID).ToList();
                            add.set = item;
                            add.contSet = DetailOTnew.Where(c => c.TimeStart.Hour == timeCheck && c.TimeStart.Minute == 0 && c.FoodSet_FoodSetID == item.FoodSetID).ToList().Count;
                        }
                        else if (timeCheck == 17)
                        {
                            add.list = DetailOTnew.Where(c => c.TimeStart.Hour == timeCheck && c.TimeStart.Minute == 0 && c.FoodSet_FoodSetID == item.FoodSetID).ToList();
                            add.set = item;
                            add.contSet = add.list.Count;
                        }
                        if (add.contSet != 0)
                        {
                            foodlist.Add(add);
                        }
                    
                }
                Addfood.time = timeCheck;
                Addfood.foodList = foodlist;

                if (Addfood.foodList.Count != 0)
                {
                    foodAdd.Add(Addfood);
                }

            }

            return foodAdd;
        }

        private List<timelist> massCarQ()
        {
            List<timelist> add = new List<timelist>();
            for (int a = 0; a < 3; a++)
            {
                int time;
                if (a == 0)
                {
                    time = 8;
                }
                else if (a == 1)
                {
                    time = 17;
                }
                else
                {
                    time = 20;
                }
                var listAdd = new timelist();
                listAdd.time = time;
                var addcarq = new List<carQ>();
                foreach (var item in Part)
                {

                    if (!item.Name.Equals("No"))
                    {
                        var list = CarQueue.Where(l => l.CarQueue_PartID == item.PartID && l.Time.Hour == time).ToList();

                        if (list.Count != 0)
                        {
                            carQ AddCarQ = new carQ();
                            AddCarQ.part = item;

                            var addList = new List<carListNumber>();
                            foreach (var i in CarType)
                            {
                                var CarTypePart = list.Where(c => c.CarQueue_CarTypeID == i.CarTypeID).ToList();
                                if (CarTypePart.Count != 0 && i.Seat != 0)
                                {
                                    carListNumber carListNumber = new carListNumber();


                                    carListNumber.CarType = i;
                                    carListNumber.maxCar = CarTypePart.Max(z => z.CarNumber);
                                    addList.Add(carListNumber);

                                }
                            }

                            AddCarQ.carListNumber = addList;
                            addcarq.Add(AddCarQ);


                        }

                    }


                }
                listAdd.carQ = addcarq;
                if (listAdd.carQ.Count != 0)
                {
                     add.Add(listAdd);
                }
               
            }

            return add;
        }

    

        private async Task onLoad(int? Did)
        {
            Department = await _context.Department.ToListAsync();
            Employee = HttpContext.Session.GetLogin(_context.Employee);
            OT = await _context.OT.FirstOrDefaultAsync(m => m.OTID == Did);
            DetailOT = await _context.DetailOT
                .Include(d => d.Employee)
                .Include(d => d.FoodSet)
                .Include(d => d.OT)
                .Include(d => d.Point.Part).Where(a => a.OT_OTID == Did).ToListAsync();
            Part = await _context.Part.Where(a => !a.Name.Equals("No")).ToListAsync();
            FoodSet = await _context.FoodSet.Where(a => !a.NameSet.Equals("No")).ToListAsync();
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
            OTs = ListOTDetail(Did);
            Depasments = OTDetailOTList();
            timelist = massCarQ();
            food = foodMass();
            LineToken = await _context.LineToken
                .Include(l => l.Company).FirstOrDefaultAsync(e => e.Company_CompanyID == Employee.Company_CompanyID);
            ViewData["Company_CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyName");
        }
        private List<Depasments> OTDetailOTList()
        {
            List<Depasments> add = new List<Depasments>();
            foreach (var i in Department)
            {
                var DataParts = DetailOTnew.Where(d => d.Employee.Department_DepartmentID == i.DepartmentID).ToList();
                Depasments DataDepasments = new Depasments();
                DataDepasments.DepasmentsName = i.DepartmentName;
                DataDepasments.DepasmentsID = i.DepartmentID;
                DataDepasments.DepasmentsCount = DataParts.Count;


                DataDepasments.CarCount = DetailOTnew.Where(d => !d.Type.Equals("No") && d.Employee.Department_DepartmentID == i.DepartmentID).ToList().Count;
                DataDepasments.FoodCount = DetailOTnew.Where(d => d.Employee.Department_DepartmentID == i.DepartmentID && !d.FoodSet.NameSet.Equals("No")).ToList().Count;
                List<Parts> Listparts = new List<Parts>();
                foreach (var j in Part)
                {
                    Parts parts = new Parts();
                    parts.PartID = j.PartID;
                    parts.PartName = j.Name;
                    IList<DetailOT> DataPart = DataParts.Where(d => !d.Point.Part.Name.Equals("No")).ToList();
                    DataPart = DataPart.Where(d => d.Employee.Department_DepartmentID == i.DepartmentID).ToList();
                    DataPart = DataPart.Where(d => d.Point.Point_PartID == j.PartID).ToList();
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
                    var DataPart = DataParts;
                    
                    DataPart = DataPart.Where(d => d.FoodSet_FoodSetID == j.FoodSetID && ((d.TimeEnd.Hour == 17 && d.TimeEnd.Minute == 0)|| (d.TimeStart.Hour == 8 && d.TimeStart.Minute == 0))).ToList();
                    foods.FoodsCount = DataPart.Count;
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
            OTsnew.countCar = DetailCarQueue.Count;
            OTsnew.countFood = DetailOTnew.Where(e => !e.FoodSet.NameSet.Equals("No")).ToList().Count;
            //foreach (var i in DetailOTnew)
            //{
            //    if (i.FoodSet.NameSet.Equals("No"))
            //    {
            //        OTsnew.countFood = OTsnew.countFood + 1;
            //    }
            //    if (!i.Type.Equals("No"))
            //    {
            //        OTsnew.countCar = OTsnew.countCar + 1;
            //    }

            //}

            return OTsnew;
        }
    }


  

    public class carListNumber
    {
        public CarType CarType { get; set; }
        public int maxCar { get; set; }
    }


    public class carQ
    {
        public Part part { get; set; }
        public IList<carListNumber> carListNumber { get; set; }
       
    }

    public class timelist
    {
        public int time { get; set; }
        public IList<carQ> carQ { get; set; }
    }

    public class foodList
    {
        public IList<DetailOT>  list { get; set; }
        public FoodSet set { get; set; }
        public int contSet { get; set; }
    }



    public class food
    {
        public int time { get; set; }
        public IList<foodList> foodList { get; set; }
    }

}
