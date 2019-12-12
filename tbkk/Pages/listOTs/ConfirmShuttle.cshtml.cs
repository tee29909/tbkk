﻿using System;
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



        public IList<test> test { get; set; }


        public string json { get; set; }





        public string foodToken = "gpLcFbnpq8RcdSP67A4vFdZMKlfz9vBDlI0IVB2TsXV";
        public string carToken = "YGWdtLg5mavVWPlBmU0CT2WcZspAguWgZljx7FXBIEk";

        public IList<FoodSet> FoodSet { get; set; }
        public IList<CarsPart> CarsPart { get; set; }
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

            OTs OTsnew = new OTs();
            DetailOT = DetailOT.Where(d => d.OT_OTID == Did).ToList();
            DetailOT = DetailOT.Where(d => d.Status.Equals("Allow")).ToList();
            DetailOTnew = DetailOT;
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
            OTs = OTsnew;


            List<Depasments> add = OTDetailOTList();
            Depasments = add;















            DetailOTnew = DetailOT;
            DetailOTnew = DetailOTnew.Where(d => d.Type.Equals("Go") || d.Type.Equals("Go and Back")).ToList();




            List<CarsPart> CarsParts = ManageCar();
            CarsPart = CarsParts;


            return Page();
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
                        DataDepasments.Parts.Add(parts);
                    }

                }
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
                        DataDepasments.Foods.Add(foods);
                    }

                }
                add.Add(DataDepasments);
            }

            return add;
        }

        private List<CarsPart> ManageCar()
        {
            List<CarsPart> CarsParts = new List<CarsPart>();

            foreach (var i in Part)
            {

                CarsPart CarsPartNew = new CarsPart();
                CarsPartNew.PartID = i.PartID;
                CarsPartNew.namePart = i.Name;
                List<Cars> CarsNew = new List<Cars>();
                int count = DetailOTnew.Where(c => c.Part_PaetID == i.PartID).ToList().Count;
                foreach (var j in CarType)
                {
                    if (j.Seat <= count)
                    {
                        Cars cars = new Cars();
                        cars.CarTypeID = j.CarTypeID;
                        cars.CarTypeName = j.NameCar;
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


                CarsPartNew.Cars = CarsNew;
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
        public async Task OnPostLineAsync(int id,int Did)
        {
            
            //food
            lineNotify("test food", foodToken);
            notifySticker("อาหารมาแล้ว",150,2, foodToken);
            //car
            lineNotify("test car", carToken);
            notifySticker("รถมาแล้ว", 160, 2, carToken);
            await onLoad(id, Did);
            //FromDataManage(Did);
        }


       

        private void notifyPicture(string msg,string url, string TOKEN)

        {

            _lineNotify(msg, 0, 0, url, TOKEN);

        }

        private void notifySticker(string msg,int stickerID, int stickerPackageID,string TOKEN)

        {

            _lineNotify(msg, stickerPackageID, stickerID, "",TOKEN);

        }

        private void lineNotify(string msg,string TOKEN)

        {

            _lineNotify(msg, 0, 0, "",TOKEN);

        }

        private void _lineNotify(string msg, int stickerPackageID, int stickerID, string pictureUrl,string TOKEN)

        {

            string token = TOKEN;

            try

            {

                var request = (HttpWebRequest)WebRequest.Create("https://notify-api.line.me/api/notify");



                var postData = string.Format("message={0}", msg);

                if (stickerPackageID > 0 && stickerID > 0)

                {

                    var stickerPackageId = string.Format("stickerPackageId={0}", stickerPackageID);

                    var stickerId = string.Format("stickerId={0}", stickerID);

                    postData += "&" + stickerPackageId.ToString() + "&" + stickerId.ToString();

                }

                if (pictureUrl != "")

                {

                    var imageThumbnail = string.Format("imageThumbnail={0}", pictureUrl);

                    var imageFullsize = string.Format("imageFullsize={0}", pictureUrl);

                    postData += "&" + imageThumbnail.ToString() + "&" + imageFullsize.ToString();

                }

                var data = Encoding.UTF8.GetBytes(postData);



                request.Method = "POST";

                request.ContentType = "application/x-www-form-urlencoded";

                request.ContentLength = data.Length;

                request.Headers.Add("Authorization", "Bearer " + token);



                using (var stream = request.GetRequestStream()) stream.Write(data, 0, data.Length);

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());

            }

        }
    }



    public class CarsPart
    {
        public int PartID { get; set; }
        public string namePart { get; set; }

        public IList<Cars> Cars = new List<Cars>();
    }


    public class OTs
    {
        public int countEmp { get; set; }
        public int countCar { get; set; }
        public int countFood { get; set; }
        
    }

    public class Cars
    {
        public int CarTypeID { get; set; }
        public string CarTypeName { get; set; }
        public int countCar { get; set; }
    }


    public class Depasments
    {
        public int DepasmentsID { get; set; }
        public string DepasmentsName { get; set; }
        public int DepasmentsCount { get; set; }
        public int CarCount { get; set; }
        public int FoodCount { get; set; }









        public IList<Parts> Parts = new List<Parts>();
        public IList<Foods> Foods  = new List<Foods>();
    }

    public class Parts
    {
        public int PartID { get; set; }
        public string PartName { get; set; }
        public int PartsCount { get; set; }
         
    }

    public class Foods
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        
        public int FoodsCount { get; set; }

        
    }

    public class test
    {
        public int testID { get; set; }
        public string testname { get; set; }

       
    }
}
