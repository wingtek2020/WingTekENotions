using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TekENotions.API.Data;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace TekENotions.API
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
            //var connection = @"Server=WINGTEK\sqlexpress;Database=TekENotions2020;Integrated Security=True";
            var connection = Configuration.GetConnectionString("Default");

            services.AddDbContext<TekENotionsContext>(options => options.UseSqlServer(connection));
            services.AddControllers();
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", build => {
                build.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                //endpoints.MapFallbackToController("Index", "Fallback");
                endpoints.MapControllerRoute(
                    name: "api",
                    pattern: "{controller}/{id?}");
                });
        }
    }
}
