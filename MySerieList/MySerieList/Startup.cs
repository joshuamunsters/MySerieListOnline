using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Interfaces;
using DataLayer;
using Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MySerieList
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<ISerieRepository, SerieRepository>();
            //services.AddTransient<ICategoryRepository, CategoryRepository>();
            //services.AddTransient<IReviewRepository, ReviewRepository>();
            // Add framework services.
            services.AddMvc();
           
                
                



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                //routes.MapRoute(name: "categoryfilter", template: "Serie/{action}/{category?}", defaults: new { Controller = "Serie", action = "List" });
                //routes.MapRoute(name: "seriepage", template: "Serie/{action}/{id?}", defaults: new { Controller = "Serie", action = "Page" });
                //routes.MapRoute(name: "seriereview", template: "Serie/{action}/{review?}", defaults: new { Controller = "Serie", action = "Page" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
