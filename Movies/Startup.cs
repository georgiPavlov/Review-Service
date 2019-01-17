﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using LibraryData;
using LibraryService;
using LibraryData.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Library
{
    public class Startup
    {
        // add a constructor, and 
        // create an instance of a 
        // configuration builder.
        // use it to configure the various 
        // configuration sources for the application.
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables(); // could add connection strings here.
            // here it is.q
            Configuration = builder.Build();
        }

        // access the configuration in a property.
        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddSingleton(Configuration);

         


            // configure ef and dbcontext.
            // ef can now work with other databases, including non-relational
            services.Configure<IdentityOptions>(options =>
            {
                // Make really weak passwords possible
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });

            services.AddIdentity<User, IdentityRole>(
    options =>
    {
        // options
    })
    .AddEntityFrameworkStores<LibraryDbContext>()
    .AddDefaultTokenProviders();



            services.AddDbContext<LibraryDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LibraryConnection")));

            // Now we can use EF to generate our database in a two-step process.
            // Write migration code we can execute to create a database and a schema.
            // ef can generate migration code by looking at a database and seeing its
            // current state.

            // Install NuGet package EntityFrameworkCore.Tools
            // in the package manager console.
            // console command - add-migration
            // console command - update-databse

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug()
               ;

          

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "Identity.Application", // Matches the name it's looking for in the exception
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "authenticationScheme", // Matches the name it's looking for in the exception
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
