using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentALM.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AssignmentALM
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
           
            var repository = new Models.BankRepository();

            var c1 = new Customer()
            {
                CustomerNumber = 1,
                FirstName = "Calle",
                LastName = "Carlsson"
            };

            var c2 = new Customer()
            {
                CustomerNumber = 2,
                FirstName = "Johan",
                LastName = "lars"
            };

            var c3 = new Customer()
            {
                CustomerNumber = 3,
                FirstName = "erik",
                LastName = "Dahl"
            };

            var a1 = new Account()
            {
                AccountHolder = c1,
                AccountNumber = 1,
                Balance = 5000
            };

            var a2 = new Account()
            {
                AccountHolder = c2,
                AccountNumber = 2,
                Balance = 327000
            };

            var a3 = new Account()
            {
                AccountHolder = c3,
                AccountNumber = 3,
                Balance = 127000
            };
            c1.Accounts.Add(a1);
            repository.Customers.Add(c1);
            repository.Accounts.Add(a1);
            c2.Accounts.Add(a2);
            repository.Customers.Add(c2);
            repository.Accounts.Add(a2);
            c3.Accounts.Add(a3);
            repository.Customers.Add(c3);
            repository.Accounts.Add(a3);

            services.AddSingleton(repository);

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=EmranBank}/{action=Index}/{id?}");
            });
        }
    }
}

       

