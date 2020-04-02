using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class SeedDataDepartment
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new tbkkdbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tbkkdbContext>>()))
            {
                // Look for any movies.

                if (context.Department.Any())
                {
                    return;   // DB has been seeded
                }

                context.Department.AddRange(
              new Department
              {
                  DepartmentName = "Information Technology",
                  Image = "Emp1.jpg",
                  Status = "open"
              }
              );
                context.Department.AddRange(
                new Department
                {
                    DepartmentName = "Production Department",
                    Image = "Emp1.jpg",
                    Status = "open"
                }
                );
                context.Department.AddRange(
                    new Department
                    {
                        DepartmentName = "Sales Department",
                        Image = "Emp1.jpg",
                        Status = "open"
                    }
                    );
                context.Department.AddRange(
                    new Department
                    {
                        DepartmentName = "Accounting Department",
                        Image = "Emp1.jpg",
                        Status = "open"
                    }
                    );
                context.Department.AddRange(
                    new Department
                    {
                        DepartmentName = "Human Resource",
                        Image = "Emp1.jpg",
                        Status = "open"
                    }
                    );

                context.SaveChanges();
                /*---------------------------------*/


            }

         
           

        }
    }
}
