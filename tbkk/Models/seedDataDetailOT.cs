using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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


                context.OT.AddRange(
                 new OT
                 {

                     TimeStart = DateTime.Parse("8:00 AM"),
                     TimeEnd = DateTime.Parse("15:00 PM"),
                     date = DateTime.Now,
                     TypeOT = DateTime.Now.ToString("dddd"),
                     TypStatus = "Open"


                 }
                 );
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


                for (int i = 1; i <= 20; i++)
                {
                    context.DetailOT.AddRange(
                                 new DetailOT
                                 {

                                     Type = "Go",
                                     CarNumber = "0",
                                     Status = "Pending for approval",
                                     Part_PaetID = 2,
                                     FoodSet_FoodSetID = 2,
                                     CarType_CarTypeID = 1,
                                     OT_OTID = 1,
                                     Employee_EmpID = i
                                 }
                                 );
                }


                context.SaveChanges();
            }
        }
    }
}
