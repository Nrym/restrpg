using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RestRpg.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestRpg
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
            services.AddMvc().AddXmlDataContractSerializerFormatters();

            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Implement Swagger UI",
                    Description = "A simple example to Implement Swagger UI",
                });
            });
            var machine = System.Environment.MachineName;
            if(machine== "NEX-PRO")
                services.AddDbContext<ApiDbContext>(option => option.UseSqlServer(@"Data Source=NEX-PRO\SQLEXPRESS;Initial Catalog=RestRpgDb;User id=sa;Password=sql;"));
            else
                services.AddDbContext<ApiDbContext>(option => option.UseSqlServer(@"Data Source=PE-IT001720\SQLEXPRESS2;Initial Catalog=RestRpgDb;User id=sa;Password=sql;"));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)//, ApiDbContext dbContext
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //dbContext.Database.EnsureCreated();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Showing API V1");
            });
        }
    }
}
