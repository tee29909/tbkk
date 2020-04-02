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

                if (context.Login.Any())
                {
                    return;   // DB has been seeded
                }


                /*---------------------------------*/


                context.Login.AddRange(
                new Login
                {
                    Username = "admin",

                    Password = "admin",

                    Login_EmployeeID = 1
                }
                );

                /*+++++++++++++++++++++++++++++++++++++++++++*/
                context.Login.AddRange(
                new Login
                {
                    Username = "user1",

                    Password = "user1",

                    Login_EmployeeID = 2
                }
                );
                context.Login.AddRange(
                new Login
                {
                    Username = "user2",

                    Password = "user2",

                    Login_EmployeeID = 3
                }
                );
                context.Login.AddRange(
                new Login
                {
                    Username = "user3",

                    Password = "user3",

                    Login_EmployeeID = 4
                }
                );
                context.Login.AddRange(
                new Login
                {
                    Username = "user4",

                    Password = "user4",

                    Login_EmployeeID = 5
                }
                );
                context.Login.AddRange(
                new Login
                {
                    Username = "user5",

                    Password = "user5",

                    Login_EmployeeID = 6
                }
                );
                context.Login.AddRange(
                new Login
                {
                    Username = "user6",

                    Password = "user6",

                    Login_EmployeeID = 7
                }
                );
                context.Login.AddRange(
                new Login
                {
                    Username = "user7",

                    Password = "user7",

                    Login_EmployeeID = 8
                }
                );
                context.Login.AddRange(
                new Login
                {
                    Username = "user8",

                    Password = "user8",

                    Login_EmployeeID = 9
                }
                );
                context.Login.AddRange(
                new Login
                {
                    Username = "user9",

                    Password = "user9",

                    Login_EmployeeID = 10
                }
                );
                context.Login.AddRange(
               new Login
               {
                   Username = "employee11",

                   Password = "employee11",

                   Login_EmployeeID = 11
               }
               );
                context.Login.AddRange(
               new Login
               {
                   Username = "employee12",

                   Password = "employee12",

                   Login_EmployeeID = 12
               }
               );
                context.Login.AddRange(
               new Login
               {
                   Username = "employee13",

                   Password = "employee13",

                   Login_EmployeeID = 13
               }
               );
                context.Login.AddRange(
               new Login
               {
                   Username = "employee14",

                   Password = "employee14",

                   Login_EmployeeID = 14
               }
               );
                context.Login.AddRange(
               new Login
               {
                   Username = "employee15",

                   Password = "employee15",

                   Login_EmployeeID = 15
               }
               );
                context.Login.AddRange(
               new Login
               {
                   Username = "employee16",

                   Password = "employee16",

                   Login_EmployeeID = 16
               }
               );
                context.Login.AddRange(
               new Login
               {
                   Username = "employee17",

                   Password = "employee17",

                   Login_EmployeeID = 17
               }
               );
                context.Login.AddRange(
               new Login
               {
                   Username = "employee18",

                   Password = "employee18",

                   Login_EmployeeID = 18
               }
               );
                context.Login.AddRange(
               new Login
               {
                   Username = "employee19",

                   Password = "employee19",

                   Login_EmployeeID = 19
               }
               );
                context.Login.AddRange(
               new Login
               {
                   Username = "employee20",

                   Password = "employee20",

                   Login_EmployeeID = 20
               }
               );

                /*+++++++++++++++++++++++++++++++++++++++++++*/

                context.CarType.AddRange(
                new CarType
                {

                    NameCar = "สองแถวสองประตู",
                    Seat = 8,
                    CompanyCarID = 1


                }
                );


                context.CarType.AddRange(
                new CarType
                {

                    NameCar = "สองแถวสี่ประตู",
                    Seat = 6,
                    CompanyCarID = 1


                }
                );
                context.FoodSet.AddRange(
              new FoodSet
              {

                  FoodSetcoManul = "No",
                  NameSet = "No",
                  Price=0,
                  Canteen_CanteenID = 1


              }
              );

                context.FoodSet.AddRange(
                new FoodSet
                {

                    FoodSetcoManul = "อาหาร",
                    NameSet = "A",
                    Price = 50,
                    Canteen_CanteenID = 1



                }
                );

                context.FoodSet.AddRange(
                new FoodSet
                {

                    FoodSetcoManul = "อาหาร",
                    NameSet = "B",
                    Price = 50,
                    Canteen_CanteenID = 1

                }
                );

                context.SaveChanges();
            }

        }
    }
}
