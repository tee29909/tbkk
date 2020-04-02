using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class SeedDataCompany
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new tbkkdbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tbkkdbContext>>()))
            {
                // Look for any movies.

                if (context.Company.Any())
                {
                    return;   // DB has been seeded
                }

                context.Company.AddRange(
                    new Company
                    {
                        CompanyName = "Tbkk",
                        Image = "Emp1.jpg",
                        Status = "Open"
                    }
                    );






                context.SaveChanges();
            }

        }
    }
}
