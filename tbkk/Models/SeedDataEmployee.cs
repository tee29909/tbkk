using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tbkk.Models
{
    public class SeedDataEmployee
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new tbkkdbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tbkkdbContext>>()))
            {
                // Look for any movies.

                if (context.Employee.Any())
                {
                    return;   // DB has been seeded
                }

                context.Employee.AddRange(
     new Employee
     {

         Employee_Num = "1",
         Salary = 20.4,
         FirstName = "admin",

        

         LastName = "admin",

         Gender = "male",



         Email = "admin@hotmail.com",

         Call = "0805694932",

         Line = "tee29909",

         Image = "Emp1.jpg",

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









                /*222222222222222222222222222222222222222222222222222222222*/





                context.Employee.AddRange(
                    new Employee
                    {
                        Employee_Num = "1",
                        Salary = 20.4,

                        FirstName = "Athena",

                        LastName = "Collins",

                        Gender = "male",

                        Email = "admin@hotmail.com",

                        Call = "0805694932",

                        Line = "tee29909",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1989-2-12"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 5,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 1,

                        Position_PositionID = 4
                    }
                    );
                context.Employee.AddRange(
                    new Employee
                    {

                        Employee_Num = "1",
                        Salary = 20.4,
                        FirstName = "Arista",

                        LastName = "Carter",

                        Gender = "male",

                        Email = "admin@hotmail.com",

                        Call = "0805694932",

                        Line = "tee29909",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1989-2-12"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 5,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 1,

                        Position_PositionID = 4
                    }
                    );
                context.Employee.AddRange(
                    new Employee
                    {

                        Employee_Num = "1",
                        Salary = 20.4,
                        FirstName = "Aria",

                        LastName = "Campbell",

                        Gender = "male",

                        Email = "admin@hotmail.com",

                        Call = "0805694932",

                        Line = "tee29909",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1989-2-12"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 5,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 1,

                        Position_PositionID = 4
                    }
                    );
                context.Employee.AddRange(
                    new Employee
                    {
                        Employee_Num = "1",
                        Salary = 20.4,

                        FirstName = "Ammie",

                        LastName = "Bennett",

                        Gender = "male",

                        Email = "admin@hotmail.com",

                        Call = "0805694932",

                        Line = "tee29909",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1989-2-12"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 4,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 1,

                        Position_PositionID = 4
                    }
                    );
                context.Employee.AddRange(
                    new Employee
                    {
                        Employee_Num = "1",
                        Salary = 20.4,

                        FirstName = "Alyssa",

                        LastName = "Beckham",

                        Gender = "male",

                        Email = "admin@hotmail.com",

                        Call = "0805694932",

                        Line = "tee29909",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1989-2-12"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 4,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 1,

                        Position_PositionID = 4
                    }
                    );
                context.Employee.AddRange(
                    new Employee
                    {
                        Employee_Num = "1",
                        Salary = 20.4,
                        FirstName = "Angela",

                        LastName = "Baker",

                        Gender = "male",

                        Email = "admin@hotmail.com",

                        Call = "0805694932",

                        Line = "tee29909",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1989-2-12"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 3,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 2,

                        Position_PositionID = 3
                    }
                    );
                context.Employee.AddRange(
                    new Employee
                    {
                        Employee_Num = "1",
                        Salary = 20.4,

                        FirstName = "Abigail",

                        LastName = "Anderson",

                        Gender = "male",

                        Email = "admin@hotmail.com",

                        Call = "0805694932",

                        Line = "tee29909",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1989-2-12"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 3,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 2,

                        Position_PositionID = 3
                    }
                    );
                context.Employee.AddRange(
                    new Employee
                    {

                        Employee_Num = "1",
                        Salary = 20.4,
                        FirstName = "Amber",

                        LastName = "Alexander",

                        Gender = "male",

                        Email = "admin@hotmail.com",

                        Call = "0805694932",

                        Line = "tee29909",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1989-2-12"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 2,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 1,

                        Position_PositionID = 2
                    }
                    );


                context.Employee.AddRange(
                    new Employee
                    {
                        Employee_Num = "1",
                        Salary = 20.4,

                        FirstName = "Amelia",

                        LastName = "Adams",

                        Gender = "male",

                        Email = "admin@hotmail.com",

                        Call = "0805694932",

                        Line = "tee29909",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1989-2-12"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 2,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 1,

                        Position_PositionID = 2
                    }
                    );

                //11
                context.Employee.AddRange(
                    new Employee
                    {
                        Employee_Num = "1",
                        Salary = 20.4,

                        FirstName = "brooke",

                        LastName = "edward",

                        Gender = "male",

                        Email = "brooke@hotmail.com",

                        Call = "0859872658",

                        Line = "brooke152",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1992-10-12"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 2,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 1,

                        Position_PositionID = 2
                    }
                   );
                //12
                context.Employee.AddRange(
                    new Employee
                    {

                        Employee_Num = "1",
                        Salary = 20.4,
                        FirstName = "alice",

                        LastName = "anissa",

                        Gender = "female",

                        Email = "alice@hotmail.com",

                        Call = "0847563259",

                        Line = "aliceWTF",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1990-7-2"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 5,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 1,

                        Position_PositionID = 3
                    }
                   );
                //13
                context.Employee.AddRange(
                    new Employee
                    {
                        Employee_Num = "1",
                        Salary = 20.4,

                        FirstName = "ava",

                        LastName = "holly",

                        Gender = "female",

                        Email = "ava@hotmail.com",

                        Call = "0698745284",

                        Line = "avaava",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1994-10-22"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 4,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 1,

                        Position_PositionID = 4
                    }
                   );
                //14
                context.Employee.AddRange(
                    new Employee
                    {

                        Employee_Num = "1",
                        Salary = 20.4,
                        FirstName = "opal",

                        LastName = "sophie",

                        Gender = "female",

                        Email = "opal@hotmail.com",

                        Call = "0897854632",

                        Line = "opal6322",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1988-12-20"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 4,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 1,

                        Position_PositionID = 3
                    }
                   );
                //15
                context.Employee.AddRange(
                    new Employee
                    {
                        Employee_Num = "1",
                        Salary = 20.4,

                        FirstName = "max",

                        LastName = "william",

                        Gender = "male",

                        Email = "maxMCU@hotmail.com",

                        Call = "0998871275",

                        Line = "mimimax",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1988-5-10"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 3,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 1,

                        Position_PositionID = 3
                    }
                   );
                //16
                context.Employee.AddRange(
                    new Employee
                    {
                        Employee_Num = "1",
                        Salary = 20.4,

                        FirstName = "layla",

                        LastName = "melyssa",

                        Gender = "female",

                        Email = "laylala@hotmail.com",

                        Call = "0875942368",

                        Line = "laylala",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1989-8-28"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 2,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 2,

                        Position_PositionID = 2
                    }
                   );
                //17
                context.Employee.AddRange(
                    new Employee
                    {
                        Employee_Num = "1",
                        Salary = 20.4,

                        FirstName = "morgen",

                        LastName = "rohan",

                        Gender = "male",

                        Email = "morgenrohan@hotmail.com",

                        Call = "0985314752",

                        Line = "morgenrohan",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1995-11-28"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 3,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 2,

                        Position_PositionID = 4
                    }
                   );
                //18
                context.Employee.AddRange(
                    new Employee
                    {

                        Employee_Num = "1",
                        Salary = 20.4,
                        FirstName = "oscar",

                        LastName = "serafim",

                        Gender = "male",

                        Email = "oscarcar@hotmail.com",

                        Call = "0986523798",

                        Line = "oscarcar",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1985-9-9"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 1,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 2,

                        Position_PositionID = 2
                    }
                   );
                //19
                context.Employee.AddRange(
                    new Employee
                    {
                        Employee_Num = "1",
                        Salary = 20.4,

                        FirstName = "evan",

                        LastName = "jacob",

                        Gender = "male",

                        Email = "evanTH@hotmail.com",

                        Call = "0988896571",

                        Line = "evanTH",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1995-10-9"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 2,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 2,

                        Position_PositionID = 3
                    }
                   );
                //20
                context.Employee.AddRange(
                    new Employee
                    {
                        Employee_Num = "1",
                        Salary = 20.4,

                        FirstName = "harry",

                        LastName = "joshua",

                        Gender = "male",

                        Email = "harry@hotmail.com",

                        Call = "0988896571",

                        Line = "harry",

                        Image = "Emp1.jpg",

                        Addr = "tbkk",

                        Date = DateTime.Parse("1988-5-19"),

                        Status = "working",

                        Company_CompanyID = 1,

                        Department_DepartmentID = 5,

                        Location_LocationID = 1,

                        EmployeeType_EmployeeTypeID = 1,

                        Position_PositionID = 4
                    }
                   );


                context.SaveChanges();
                /*---------------------------------*/


            }

         
           

        }
    }
}
