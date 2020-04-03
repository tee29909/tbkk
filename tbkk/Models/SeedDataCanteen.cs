using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class SeedDataCanteen
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new tbkkdbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tbkkdbContext>>()))
            {
                // Look for any movies.

                if (context.Canteen.Any())
                {
                    return;   // DB has been seeded
                }
                context.Canteen.AddRange(
                new Canteen
                {
                    Name = "nabuy",
                    Email = "Canteen@hotmail.com",
                    Line = "tee29909",
                    Call = "0805694931",
                    Status = "Open",
                    Canteen_CompanyID = 1
                }
                );
                context.SaveChanges();
                /*---------------------------------*/
            }
        }
    }
}
