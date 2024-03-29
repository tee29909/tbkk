﻿using Microsoft.EntityFrameworkCore;
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
                                     Point_PointID = new Random().Next(2, 6),
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



        }





    }
}
