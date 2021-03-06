﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeBox3._0.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using Domain.Abstract;
using Domain.Concrete;
using Domain.DataContexts;
using Domain.Entities;

namespace RecipeBox3._0
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private string _connection;
        private string _connectionTwo;
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("AuthenticationDbContextConnection"));
            builder.Password = Configuration["recipePwd"];
            _connection = builder.ConnectionString;
            var builderTwo = new SqlConnectionStringBuilder(Configuration.GetConnectionString("RecipeDbContextConnection"));
            builderTwo.Password = Configuration["recipePwd"];
            _connectionTwo = builderTwo.ConnectionString;
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });
            
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                
            });
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                options.ExcludedHosts.Add("example.com");
                options.ExcludedHosts.Add("www.example.com");
            });
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 5001;
            });
            services.AddDbContext<AuthenticationDbContext>(options =>
                options.UseSqlServer(_connection));
             services.AddDefaultIdentity<IdentityUser>()
            .AddDefaultUI(UIFramework.Bootstrap4)
            .AddEntityFrameworkStores<AuthenticationDbContext>();
            services.AddDbContext<RecipeDbContext>(options =>
            {
                options.UseSqlServer(_connectionTwo);
            });
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["facebookID"];
                facebookOptions.AppSecret = Configuration["FacebookSecret"];
            });
            services.Configure<RecipeBox3._0.Services.SendGrid>(Configuration);
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<ICrudRepository<Recipe>, CrudRepository>();
            services.AddScoped<IUserRepository, UserDataRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddSessionStateTempDataProvider();
            services.AddSession();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}