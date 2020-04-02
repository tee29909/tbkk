using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class SeedDataPosition
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new tbkkdbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tbkkdbContext>>()))
            {
                // Look for any movies.

                if (context.Position.Any())
                {
                    return;   // DB has been seeded
                }

               

                context.Position.AddRange(
                new Position
                {
                    PositionName = "admin"
                }
                );

                context.Position.AddRange(
                new Position
                {
                    PositionName = "Manager"
                }
                );
                context.Position.AddRange(
                new Position
                {
                    PositionName = "Employee"
                }
                );
                context.Position.AddRange(
               new Position
               {
                   PositionName = "CEO"
               }
               );

                context.SaveChanges();
                /*---------------------------------*/


            }

          

        }
    }
}
