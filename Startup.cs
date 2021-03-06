﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyPOS.Database;
using MyPOS.Extensions;
using MyPOS.Middlewares;
using MyPOS.Services;

namespace MyPOS
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.ConfigureDatabase(Configuration);
            services.AddTransient<ProductService>();
            services.AddSingleton<UtilService>();

            // DI HttpContext
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseCustomMiddleware();

            app.UseStaticFiles();
            app.UseCookiePolicy();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "custom",
                    template: "Meng",
                    defaults: new { Controller = "product", Action = "privacy" });

                routes.MapRoute(
                    name: "custom_V2",
                    template: "{Controller}/Meng",
                    defaults: new { Controller = "product", Action = "privacy" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=Index}/{id?}");

                // routes
                // .MapRoute(
                //     name: "custom",
                //     template: "Meng",
                //     defaults : new {Controller = "product", Action = "privacy"})

                // .MapRoute(
                //     name: "custom_V2",
                //     template: "{Controller}/Meng",
                //     defaults : new {Controller = "product", Action = "privacy"})

                // .MapRoute(
                //     name: "default",
                //     template: "{controller=Product}/{action=Index}/{id?}");


            });
        }
    }
}
