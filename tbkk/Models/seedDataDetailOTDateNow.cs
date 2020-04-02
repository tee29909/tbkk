using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class seedDataDetailOTDateNow
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var date = DateTime.Now;
            date = new DateTime(date.Year, date.Month, date.Day);
            using (var context = new tbkkdbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tbkkdbContext>>()))
            {
                context.OT.AddRange(
                new OT
                {
                    TimeStart = new DateTime(date.Year, date.Month, date.Day, 8, 0, 0),
                    TimeEnd = new DateTime(date.Year, date.Month, date.Day, 15, 0, 0),
                    date = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0),
                    TypeOT = date.ToString("dddd", new CultureInfo("en-US")),
                    TypStatus = "Open",
                    OT_CompanyID = 1
                }
                );

                context.SaveChanges();
            }




            using (var context = new tbkkdbContext(
               serviceProvider.GetRequiredService<
                   DbContextOptions<tbkkdbContext>>()))
            {
                var OT = context.OT.FirstOrDefault(e => e.date == date);



                for (int j = 1; j <= 20; j++)
                {

                    int random = new Random().Next(1, 3);
                    DateTime Start = (!((int)OT.date.DayOfWeek == 0 || (int)OT.date.DayOfWeek == 6)) ? new DateTime(OT.date.Year, OT.date.Month, OT.date.Day, 17, 0, 0) : new DateTime(OT.date.Year, OT.date.Month, OT.date.Day, 8, 0, 0);
                    DateTime End = (!((int)OT.date.DayOfWeek == 0 || (int)OT.date.DayOfWeek == 6)) ? new DateTime(OT.date.Year, OT.date.Month, OT.date.Day, 20, 0, 0) : (random % 2 == 0) ? new DateTime(OT.date.Year, OT.date.Month, OT.date.Day, 17, 0, 0) : new DateTime(OT.date.Year, OT.date.Month, OT.date.Day, 20, 0, 0);
                    context.DetailOT.AddRange(
                             new DetailOT
                             {
                                 TimeStart = Start,
                                 TimeEnd = End,
                                 Hour = End - Start,
                                 Type = (!((int)OT.date.DayOfWeek == 0 || (int)OT.date.DayOfWeek == 6)) ? "Back" : (random == 1) ? "Go" : (random == 2) ? "Back" : "Go and Back",
                                 Status = "Allow",
                                 Point_PointID = new Random().Next(2, 6),
                                 FoodSet_FoodSetID = new Random().Next(2, 4),
                                 OT_OTID = OT.OTID,
                                 Employee_EmpID = j,
                                 Employee_UserAdd_EmpID = 20
                             }
                             );
                }

                context.SaveChanges();
            }
        }
    }
}
