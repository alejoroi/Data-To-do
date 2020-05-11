using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using webapp.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace webapp
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
            services.AddControllers();
            services.AddCors(opt=> {
                opt.AddPolicy("allowall",builder => 
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

             
                 });

            services.AddDbContextPool<TodoContext>(opt => opt
            .UseMySql("server=localhost;Database=todo;User=root;", 
            mySqlOptions => mySqlOptions
            .ServerVersion(new Version(10,4,11), ServerType.MariaDb))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("allowall");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
