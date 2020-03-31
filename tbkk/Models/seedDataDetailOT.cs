using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class seedDataDetailOT
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new tbkkdbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tbkkdbContext>>()))
            {

                if (context.OT.Any())
                {
                    return;
                }



                for(DateTime i = new DateTime(2019,1,1);i.Year<2020;i = i.AddDays(1))
                {
                   
                    if(!((int)i.DayOfWeek==0 || (int)i.DayOfWeek == 6))
                    {
                       
                        context.OT.AddRange(
                     new OT
                     {
                         TimeStart = new DateTime(i.Year,i.Month,i.Day,8,0,0),
                         TimeEnd = new DateTime(i.Year, i.Month, i.Day, 15, 0, 0),
                         date = new DateTime(i.Year, i.Month, i.Day,0,0,0),
                         TypeOT = i.ToString("dddd",new CultureInfo("en-US")),
                         TypStatus = "Close",
                         OT_CompanyID = 1
                     }
                     );

                    }
                    if ((int)i.DayOfWeek == 5)
                    {
                        var a = new DateTime(i.Year, i.Month, i.Day);
                        a = a.AddDays(1);
                        var b = new DateTime(i.Year, i.Month, i.Day);
                        b = b.AddDays(2);
                        context.OT.AddRange(
                    new OT
                    {
                        TimeStart = new DateTime(i.Year, i.Month, i.Day, 8, 0, 0),
                        TimeEnd = new DateTime(i.Year, i.Month, i.Day, 15, 0, 0),
                        date = a,
                        TypeOT = a.ToString("dddd", new CultureInfo("en-US")),
                        TypStatus = "Close",
                         OT_CompanyID = 1
                    }
                    );
                        
                        context.OT.AddRange(
                    new OT
                    {
                        TimeStart = new DateTime(i.Year, i.Month, i.Day, 8, 0, 0),
                        TimeEnd = new DateTime(i.Year, i.Month, i.Day, 15, 0, 0),
                        date = b,
                        TypeOT = b.ToString("dddd", new CultureInfo("en-US")),
                        TypStatus = "Close",
                        OT_CompanyID = 1

                    }
                    );
                    }

                }

                context.SaveChanges();
            }




            using (var context = new tbkkdbContext(
               serviceProvider.GetRequiredService<
                   DbContextOptions<tbkkdbContext>>()))
            {

                
                if (context.DetailOT.Any())
                {
                    return;
                }
                List<OT> OT = new List<OT>();
                OT = context.OT.ToList();

                foreach (var item in OT)
                {

               

               
                    for (int j = 1; j <= 20; j++)
                    {

                        int random = new Random().Next(1, 3);
                        DateTime Start = (!((int)item.date.DayOfWeek == 0 || (int)item.date.DayOfWeek == 6)) ? new DateTime(item.date.Year, item.date.Month, item.date.Day, 17, 0, 0) : new DateTime(item.date.Year, item.date.Month, item.date.Day, 8, 0, 0);
                        DateTime End = (!((int)item.date.DayOfWeek == 0 || (int)item.date.DayOfWeek == 6)) ? new DateTime(item.date.Year, item.date.Month, item.date.Day, 20, 0, 0) : (random % 2 == 0) ? new DateTime(item.date.Year, item.date.Month, item.date.Day, 17, 0, 0) : new DateTime(item.date.Year, item.date.Month, item.date.Day, 20, 0, 0);
                        context.DetailOT.AddRange(
                                 new DetailOT
                                 {
                                     TimeStart = Start,
                                     TimeEnd = End,
                                     Hour = End - Start,
                                     Type = (!((int)item.date.DayOfWeek == 0 || (int)item.date.DayOfWeek == 6)) ? "Back" : (random == 1) ? "Go" : (random == 2) ? "Back" : "Go and Back",
                                     Status = "Allow",
                                     Part_PaetID = new Random().Next(2, 6),
                                     FoodSet_FoodSetID = new Random().Next(2, 4),
                                     OT_OTID = item.OTID,
                                     Employee_EmpID = j,
                                     Employee_UserAdd_EmpID = 20
                                 }
                                 );
                    }
                    
                


                }
                context.SaveChanges();
            }















            using (var context = new tbkkdbContext(
              serviceProvider.GetRequiredService<
                  DbContextOptions<tbkkdbContext>>()))
            {


                if (context.CarQueue.Any())
                {
                    return;
                }
                var ListOT = context.OT.ToList();




                IList<Part> Part=context.Part.ToList();
                IList<CarType> CarType= context.CarType.ToList();

                foreach (var item in ListOT)
                {
                    var OT = item;
                    var DetailOT = context.DetailOT.Where(d => d.OT_OTID == item.OTID).ToList();
                    IList<CarsPart> Round_8 = new List<CarsPart>();
                    IList<CarsPart> Round_17 = new List<CarsPart>();
                    IList<CarsPart> Round_20 = new List<CarsPart>();

                    IList<DetailOT> mDetailOTnew;
                if (OT.TypeOT.Equals("Saturday") || OT.TypeOT.Equals("Sunday"))
                {
                    mDetailOTnew = DetailOT.Where(d => (d.Type.Equals("Go") || d.Type.Equals("Go and Back")) && d.TimeStart.Hour == 8 && d.TimeStart.Minute == 0).ToList();
                    Round_8 = ManageCar(mDetailOTnew, Part, CarType);
                    mDetailOTnew = DetailOT.Where(d => (d.Type.Equals("Back") || d.Type.Equals("Go and Back")) && d.TimeEnd.Hour == 17 && d.TimeEnd.Minute == 0).ToList();
                    Round_17 = ManageCar(mDetailOTnew, Part, CarType);
                    mDetailOTnew = DetailOT.Where(d => (d.Type.Equals("Back") || d.Type.Equals("Go and Back")) && d.TimeEnd.Hour == 20 && d.TimeEnd.Minute == 0).ToList();
                    Round_20 = ManageCar(mDetailOTnew, Part, CarType);
                    }
                else
                {
                    mDetailOTnew = DetailOT.Where(d => d.Type.Equals("Back") && d.TimeEnd.Hour == 20 && d.TimeEnd.Minute == 0).ToList();
                    Round_20 = ManageCar(mDetailOTnew, Part, CarType);
                }









                    if (Round_8.Any())
                    {
                        int time = 8;
                        string type = "Go";
                        IList<CarsPart> managecarNEW = Round_8;





                        foreach (var list in managecarNEW)
                        {
                            int index = managecarNEW.IndexOf(list);
                            List<DetailOT> empList;

                            try
                            {
                                empList = list.DetailOT.Where(e => e.Part_PaetID == list.PartID).ToList();
                            }
                            catch (Exception)
                            {
                                empList = new List<DetailOT>();
                            }


                            foreach (var j in list.ListCars)
                            {
                                
                                int index2 = managecarNEW[index].ListCars.IndexOf(j);
                                for (int i = 0; i < managecarNEW[index].ListCars[index2].countCar; i++)
                                {

                                    CarQueue createCarQueue = new CarQueue();
                                    createCarQueue.CarNumber = i + 1;
                                    createCarQueue.Type = type;
                                    createCarQueue.CarQueue_OTID = item.OTID;
                                    createCarQueue.Time = new DateTime(OT.date.Year, OT.date.Month, OT.date.Day, time, 0, 0);
                                    createCarQueue.CarQueue_PartID = list.PartID;
                                    createCarQueue.CarQueue_CarTypeID = j.CarTypeID;


                                    context.CarQueue.AddRange(createCarQueue);




                                    //for (int q = 1; q <= j.seed; q++)
                                    //{
                                    //    if (Emp == empList.Count)
                                    //    {
                                    //        break;
                                    //    }
                                    //    DetailCarQueue createDetailCarQueue = new DetailCarQueue();
                                    //    createDetailCarQueue.DetailCarQueue_EmployeeID = empList[Emp].Employee_EmpID;
                                    //    createDetailCarQueue.DetailCarQueue_CarQueueID = createCarQueue.CarQueueID;


                                    //    context.DetailCarQueue.AddRange(createDetailCarQueue);
                                        
                                    //    Emp = Emp + 1;
                                        
                                    //}



                                }
                            }
                        }





                       

                    }
                    


                    if (Round_17.Any())
                    {
                        int time = 17;
                        string type = "Back";
                        IList<CarsPart> managecarNEW = Round_17;

                        

                        foreach (var list in managecarNEW)
                        {
                            int index = managecarNEW.IndexOf(list);
                            List<DetailOT> empList;

                            try
                            {
                                empList = list.DetailOT.Where(e => e.Part_PaetID == list.PartID).ToList();
                            }
                            catch (Exception)
                            {
                                empList = new List<DetailOT>();
                            }


                            foreach (var j in list.ListCars)
                            {
                                int Emp = 0;
                                int index2 = managecarNEW[index].ListCars.IndexOf(j);
                                for (int i = 0; i < managecarNEW[index].ListCars[index2].countCar; i++)
                                {

                                    CarQueue createCarQueue = new CarQueue();
                                    createCarQueue.CarNumber = i + 1;
                                    createCarQueue.Type = type;
                                    createCarQueue.CarQueue_OTID = item.OTID;
                                    createCarQueue.Time = new DateTime(OT.date.Year, OT.date.Month, OT.date.Day, time, 0, 0);
                                    createCarQueue.CarQueue_PartID = list.PartID;
                                    createCarQueue.CarQueue_CarTypeID = j.CarTypeID;


                                    context.CarQueue.AddRange(createCarQueue);




                                    //for (int q = 1; q <= j.seed; q++)
                                    //{
                                    //    if (Emp == empList.Count)
                                    //    {
                                    //        break;
                                    //    }
                                    //    DetailCarQueue createDetailCarQueue = new DetailCarQueue();
                                    //    createDetailCarQueue.DetailCarQueue_EmployeeID = empList[Emp].Employee_EmpID;
                                    //    createDetailCarQueue.DetailCarQueue_CarQueueID = createCarQueue.CarQueueID;


                                    //    context.DetailCarQueue.AddRange(createDetailCarQueue);

                                    //    Emp = Emp + 1;

                                    //}



                                }
                            }
                        }

                    }
                   

                    if (Round_20.Any())
                    {
                        int time = 20;
                        string type = "Back";
                        IList<CarsPart> managecarNEW = Round_20;

                        

                        foreach (var list in managecarNEW)
                        {
                            int index = managecarNEW.IndexOf(list);
                            List<DetailOT> empList;

                            try
                            {
                                empList = list.DetailOT.Where(e => e.Part_PaetID == list.PartID).ToList();
                            }
                            catch (Exception)
                            {
                                empList = new List<DetailOT>();
                            }


                            foreach (var j in list.ListCars)
                            {
                                
                                int index2 = managecarNEW[index].ListCars.IndexOf(j);
                                for (int i = 0; i < managecarNEW[index].ListCars[index2].countCar; i++)
                                {

                                    CarQueue createCarQueue = new CarQueue();
                                    createCarQueue.CarNumber = i + 1;
                                    createCarQueue.Type = type;
                                    createCarQueue.CarQueue_OTID = item.OTID;
                                    createCarQueue.Time = new DateTime(OT.date.Year, OT.date.Month, OT.date.Day, time, 0, 0);
                                    createCarQueue.CarQueue_PartID = list.PartID;
                                    createCarQueue.CarQueue_CarTypeID = j.CarTypeID;


                                    context.CarQueue.AddRange(createCarQueue);




                                    //for (int q = 1; q <= j.seed; q++)
                                    //{
                                    //    if (Emp == empList.Count)
                                    //    {
                                    //        break;
                                    //    }
                                    //    DetailCarQueue createDetailCarQueue = new DetailCarQueue();
                                    //    createDetailCarQueue.DetailCarQueue_EmployeeID = empList[Emp].Employee_EmpID;
                                    //    createDetailCarQueue.DetailCarQueue_CarQueueID = createCarQueue.CarQueueID;


                                    //    context.DetailCarQueue.AddRange(createDetailCarQueue);

                                    //    Emp = Emp + 1;

                                    //}



                                }
                            }
                        }

                    }
                    
                    


                    //_context.CarsPart.Add(Round_8);


                    //Your logic here using Products and statusId 

                    

                }





                




                context.SaveChanges();
            }
        }

        

        private static List<CarsPart> ManageCar(IList<DetailOT> mDetailOTnew, IList<Part> Part, IList<CarType> CarType)
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
                    if (j.Seat != 0)
                    {
                        Cars cars = new Cars();
                        if (j.Seat <= count)
                        {

                            cars.CarTypeID = j.CarTypeID;
                            cars.CarTypeName = j.NameCar;
                            cars.seed = j.Seat;


                            int add = count / j.Seat;
                            count = count % j.Seat;
                            cars.countCar = add;
                            CarsNew.Add(cars);

                        }
                        else
                        {

                            cars.CarTypeID = j.CarTypeID;
                            cars.CarTypeName = j.NameCar;
                            cars.seed = j.Seat;
                            cars.countCar = 0;
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
                if (mDetailOTnew.Where(d => d.Part_PaetID == i.PartID && !i.Name.Equals("No")).ToList().Count != 0)
                {
                    CarsParts.Add(CarsPartNew);
                }
            }

            return CarsParts;
        }




    }
}
