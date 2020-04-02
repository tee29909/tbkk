using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class SeedDataLocation
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new tbkkdbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tbkkdbContext>>()))
            {
                // Look for any movies.

                if (context.Location.Any())
                {
                    return;   // DB has been seeded
                }

                context.Location.AddRange(
                  new Location
                  {
                      LocationName = "2t30",
                      Note = "note",
                      Status = "Open"
                  }
                  );

                context.SaveChanges();
                /*---------------------------------*/


            }

         
           

        }
    }
}
