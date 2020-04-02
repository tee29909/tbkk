using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class SeedDataCompanyCar
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new tbkkdbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tbkkdbContext>>()))
            {
                // Look for any movies.

                if (context.CompanyCar.Any())
                {
                    return;   // DB has been seeded
                }
                context.CompanyCar.AddRange(
               new CompanyCar
               {
                   NameCompanyCar = "transport",
                   Seat = "Canteen@hotmail.com",
                   Line = "tee29909",
                   Call = "0805694931",
                   Status = "Open",
                   Company_CompanyID = 1

               }
               );


                context.SaveChanges();
                /*---------------------------------*/


            }

         
           

        }
    }
}
