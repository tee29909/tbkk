using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class SeedDataPart
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new tbkkdbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tbkkdbContext>>()))
            {
                // Look for any movies.

                if (context.Part.Any())
                {
                    return;   // DB has been seeded
                }

               

               

               context.Part.AddRange(
               new Part
               {

                   Name = "No",
                   Price = 0,


               }
               );


                context.Part.AddRange(
                new Part
                {

                    Name = "บางแสน",
                    Price = 200,


                }
                );

                context.Part.AddRange(
                new Part
                {

                    Name = "พัทยา",
                    Price = 500,


                }
                );

                context.Part.AddRange(
                new Part
                {

                    Name = "บ่านบึง",
                    Price = 400,


                }
                );

                context.Part.AddRange(
                new Part
                {

                    Name = "พนัสนิคม",
                    Price =100,


                }
                );

                context.SaveChanges();
            }

        }
    }
}
