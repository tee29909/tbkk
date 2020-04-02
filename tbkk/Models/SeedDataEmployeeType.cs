using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class SeedDataEmployeeType
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new tbkkdbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tbkkdbContext>>()))
            {
                // Look for any movies.

                if (context.EmployeeType.Any())
                {
                    return;   // DB has been seeded
                }


                context.EmployeeType.AddRange(
                                   new EmployeeType
                                   {
                                       EmployeeTypeName = "Full Time"
                                   }
                                   );
                context.EmployeeType.AddRange(
                   new EmployeeType
                   {
                       EmployeeTypeName = "Part Time"
                   }
                   );




                context.SaveChanges();
                /*---------------------------------*/


            }

          

        }
    }
}
