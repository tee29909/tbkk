using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class SeedDataPoint
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
           
            using (var context = new tbkkdbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tbkkdbContext>>()))
            {
                if (context.Point.Any())
                {
                    return;   // DB has been seeded
                }

                var paty = context.Part.ToList();
                var partNo = paty.FirstOrDefault(e =>e.Name.Equals("No"));
                context.Point.AddRange(
                new Point
                {
                    NamePoint = "No",
                    Point_PartID = partNo.PartID
                }
                );

                paty = paty.Where(e => !e.Name.Equals("No")).ToList();

                foreach (var item in paty)
                {
                    context.Point.AddRange(
                new Point
                {
                    NamePoint = "aa"+ item.PartID,
                    Point_PartID = item.PartID
                }
                ); 

                }
               


                context.SaveChanges();
            }

        }
    }
}
