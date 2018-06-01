using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Domasno_2.Models;
using AutoMapper;
using Domasno_2.Services;

namespace Domasno_2
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

            // automapper
            services.AddAutoMapper(typeof(ClassMappings));
            services.AddMvc();
            services.AddDbContext<Domasno_2Context>(options =>options.UseSqlServer(Configuration.GetConnectionString("Domasno_2Context")));
            services.AddOptions();
            services.Configure<CommonOptions>(Configuration.GetSection("CommonOptions"));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            string tst = Configuration["Common:WebSiteUrl"];
            string tst2= Configuration["testiranje"];


            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areasRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                //routes.MapRoute("title", "title/{*index}",defaults: new { controller = "Title", action = "Index" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //app.UseMvcWithDefaultRoute();
        }
    }
}
