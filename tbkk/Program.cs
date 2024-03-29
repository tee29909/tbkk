using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using tbkk.Models;
using tbkk.Pages;

namespace tbkk
{
    public class Program
    {
       
            

        public static void Main(string[] args)
        {

            //CultureInfo.CurrentUICulture = new CultureInfo("en-US", false);
            
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();


            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogDebug( "22222222222222222222222222222");



                    SeedDataCompany.Initialize(services);
                    SeedDataPosition.Initialize(services);
                    SeedDataEmployeeType.Initialize(services);
                    SeedDataLocation.Initialize(services);
                    SeedDataDepartment.Initialize(services);

                    SeedDataCanteen.Initialize(services);
                    SeedDataCompanyCar.Initialize(services);



                    SeedDataPart.Initialize(services);
                    SeedDataPoint.Initialize(services);


                    

                    SeedDataEmployee.Initialize(services);


                    
                    

                    SeedData.Initialize(services);


                    
                    
                    
                    
                   
                    SeedDataLineToken.Initialize(services);



                   
                    

                   



                    //seedDataDetailOT.Initialize(services);
                    
                    //seedDataDetailOTDateNow.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
