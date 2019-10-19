using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new tbkkdbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tbkkdbContext>>()))
            {
                // Look for any movies.
               
                    context.Position.AddRange(
                    new Position
                    {
                        PositionName = "admin"
                    }
                    );
                
               /* ---------------------------------*/
                
                    context.EmployeeType.AddRange(
                    new EmployeeType
                    {
                        EmployeeTypeName = "Part Time"
                    }
                    );
                

                
                    context.EmployeeType.AddRange(
                    new EmployeeType
                    {
                        EmployeeTypeName = "Full Time"
                    }
                    );
                
                /*---------------------------------*/
               
                    context.Location.AddRange(
                    new Location
                    {
                        LocationName = "2t30",
                        Note = "note"
                    }
                    );
                
                /*---------------------------------*/
                
                    context.Department.AddRange(
                    new Department
                    {
                        DepartmentName = "IT",
                        Image = "null",
                        Status = "open"
                    }
                    );
                
                /*---------------------------------*/
                
                    context.Company.AddRange(
                    new Company
                    {
                        CompanyName = "Tbkk",
                        Image = "null",
                        Status = "open"
                    }
                    );
                
                /*---------------------------------*/
               
                    context.Employee.AddRange(
                    new Employee
                    {


                        FirstName = "admin",

                        LastName = "admin",

                        Gender = "male",

                        Email = "admin@hotmail.com",

                        Call = "0805694932",

                        Line = "tee29909",

                        Image = "null",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1989-2-12"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 1,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 1,

                        Position_PositionID = 1
                    }
                    );
                
                /*---------------------------------*/
               
                
                    context.Login.AddRange(
                    new Login
                    {
                        Username = "admin",

                        Password = "admin",

                        Employee_EmployeeID = 1
                    }
                    );
                




                context.SaveChanges();
            }
        }
    }
}
