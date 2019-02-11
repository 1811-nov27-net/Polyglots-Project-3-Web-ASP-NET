using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project3_Site_MVC.DataAccess;
using Project3_Site_MVC.DataAccess.Repositories;
using Project3_Site_MVC.Library;
using Project3_Site_MVC.Library.RepositoriesInterfaces;

namespace Project3_Site_MVC.Web
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

            //Repositories
            services.AddScoped<IOrderHistory, OrderHistoryRepository>();

            //Mapper
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Orderhistory, OrderHistory>();
                cfg.CreateMap<OrderHistory, Orderhistory>();
            });

            //DBContext
            services.AddDbContext<admin_order_processContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "searchOrder",
                    "OrderHistory/Search/{column?}/{order?}/{search?}",
                    new { controller = "OrderHistory", action = "Search" }
                );


                routes.MapRoute(
                    "SendEmail",
                    "Email/Send",
                    new { controller = "Email", action = "Send" }
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
