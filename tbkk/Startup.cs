﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using tbkk.Models;
using System.Threading;


using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace tbkk
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            ///lodSesstion
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddMemoryCache();



            //        services.AddLocalization(options => options.ResourcesPath = "resources");
            //        services.Configure<RequestLocalizationOptions>(options =>
            //        {
            //            var supportedCultures = new[]
            //             {
            //    new CultureInfo("en"),
            //    new CultureInfo("de"),
            //    new CultureInfo("fr"),
            //    new CultureInfo("es"),
            //    new CultureInfo("ru"),
            //    new CultureInfo("ja"),
            //    new CultureInfo("ar"),
            //    new CultureInfo("zh"),
            //    new CultureInfo("en-GB")
            //};
            //            options.DefaultRequestCulture = new RequestCulture("en-GB");
            //            options.SupportedCultures = supportedCultures;
            //            options.SupportedUICultures = supportedCultures;
            //        });
            //        services.AddSingleton<CommonLocalizationService>();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
                //By default the below will be set to whatever the server culture is. 
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US") };

                options.RequestCultureProviders = new List<IRequestCultureProvider>();
            });




            ///razor start
            services.AddRazorPages();

            //DBcotext



            services.AddDbContext<tbkkdbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("tbkkdbContext")));





            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

           
            //session start
            app.UseSession();


            app.UseRouting();











            //var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
            //app.UseRequestLocalization(localizationOptions);
            app.UseRequestLocalization();










            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

           

        }
    }
}
