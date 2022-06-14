using Album.Api.Database;
using Album.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;

namespace Album.Api
{
    public class Startup
    {
        //public string ConnectionString { get; set; }//db string

  
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //ConnectionString = Configuration.GetConnectionString("DefaultConnection");//db string initilize
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHealthChecks();

            //configure DbContext postgresql
            //services.AddDbContext<AppDbContext>(options => options.UseNpgsql(ConnectionString)); //db string reference

            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                .AddJsonFile("appsettings.json")
                                                .Build();
            services.AddDbContext<AppDbContext>(options =>
                                               options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


            // inject all repositories that extend ServiceBase            
            Assembly.GetAssembly(typeof(ServiceBase))
                    .GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(ServiceBase)))
                    .ToList()
                    .ForEach(t => services.AddScoped(t));


            // Set logging in console to warning level
            services.AddLogging(
               builder =>
               {
                   builder.AddFilter("Microsoft", LogLevel.Warning)
                          .AddFilter("System", LogLevel.Warning)
                          .AddFilter("NToastNotify", LogLevel.Warning)
                          .AddConsole()
                          .AddDebug();
               });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

/*            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller=HelloController}/{action=Index}/{id?}");
            });*/
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
                //endpoints.MapHealthChecks("/health");
            });

            /*      app.UseEndpoints(endpoints =>
                  {
                      endpoints.MapGet("/", async context =>
                      {
                          await context.Response.WriteAsync("Hello World!");
                      });
                  });*/
        }
    }
}
