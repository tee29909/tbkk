using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class SeedDataLineToken
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
           
            using (var context = new tbkkdbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tbkkdbContext>>()))
            {
                if (context.LineToken.Any())
                {
                    return;   // DB has been seeded
                }

               
                context.LineToken.AddRange(
                new LineToken
                {
                    TokenCar = "YGWdtLg5mavVWPlBmU0CT2WcZspAguWgZljx7FXBIEk",
                    TokenFood= "gpLcFbnpq8RcdSP67A4vFdZMKlfz9vBDlI0IVB2TsXV",
                    Company_CompanyID = 1
                }
                );

                

               


                context.SaveChanges();
            }

        }
    }
}
