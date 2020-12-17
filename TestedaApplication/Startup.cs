using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using TestedaApplication.service;
using Microsoft.AspNetCore.Identity;
using TestedaApplication.Data;

namespace TestedaApplication
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("Project", new Config());

            services.AddDbContext<Data.AppDbContext>(options =>
                options.UseSqlServer(Config.ConnectionString));

            services.AddIdentity<IdentityUser, IdentityRole>( opts =>
            {
                opts.User.RequireUniqueEmail = false;
                opts.Password.RequireDigit = false;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(optionsAuth =>
            {
                optionsAuth.Cookie.Name = "ClassCarAuth";
                optionsAuth.Cookie.HttpOnly = true;
                optionsAuth.LoginPath = "/account/login";
                optionsAuth.AccessDeniedPath = "/account/accessdenied";
                optionsAuth.SlidingExpiration = true;
            });


            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
                x.AddPolicy("UserArea",  policy => { policy.RequireRole("user"); });
            });

            services.AddControllersWithViews( x =>
            {
                x.Conventions.Add( new AreaAuthorization("Admin", "AdminArea") );
                x.Conventions.Add( new AreaAuthorization("User", "UserArea") );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Admin}/{action=ListAd}/{id?}");
                endpoints.MapControllerRoute("user", "{area:exists}/{controller=Usera}/{action=ListUs}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Car}/{action=List}/{id?}");
            });
        }
    }
}
