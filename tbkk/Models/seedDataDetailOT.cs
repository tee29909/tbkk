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



                for(int i = 1;i<=7;i++)
                {
                      context.OT.AddRange(
                     new OT
                     {
                         TimeStart = new DateTime(2019,12,i,8,0,0),
                         TimeEnd = new DateTime(2019, 12, i, 15, 0, 0),
                         date = new DateTime(2019, 12, i),
                         TypeOT = new DateTime(2019, 12, i).ToString("dddd",new CultureInfo("en-US")),
                         TypStatus = "Manage Car"
                     }
                     );
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

                for (int i = 1; i <= 7; i++)
                {
                    for (int j = 1; j <= 20; j++)
                {

                    int random = new Random().Next(1, 4);
                    DateTime Start = (i != 1 && i != 7) ? new DateTime(2019, 12, i, 17, 0, 0) : new DateTime(2019, 12, i, 8, 0, 0);
                    DateTime End = (i != 1 && i != 7) ? new DateTime(2019, 12, i, 20, 0, 0) : (random % 2 == 0) ? new DateTime(2019, 12, i, 17, 0, 0) : new DateTime(2019, 12, i, 20, 0, 0);
                        context.DetailOT.AddRange(
                                 new DetailOT
                                 {
                                     TimeStart = Start,
                                     TimeEnd = End,
                                     Hour = End - Start,
                                     Type = (i != 1 && i!=7) ? "Back" : (random == 1) ? "Go" : (random == 2) ? "Back" : "Go and Back",
                                     Status = "Allow",
                                     Part_PaetID = new Random().Next(2, 6),
                                     FoodSet_FoodSetID = new Random().Next(2, 4),
                                     OT_OTID = i,
                                     Employee_EmpID = j
                                 }
                                 );
                }
                }
                context.SaveChanges();
            }
        }
    }
}
