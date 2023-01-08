
using FluentValidation.AspNetCore;
using LVRMWebAPI.Data;
using LVRMWebAPI.Infrastructure;
using LVRMWebAPI.Models;
using LVRMWebAPI.Repository;
using LVRMWebAPI.ScronJob;
using LVRMWebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Test Suresh
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IScopedSevices, MyScopServices>();
            services.AddHostedService<DatashakeCronjboService>();
            services.AddDbContext<PSM_DevContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:DBConnectionPSM"]));
            services.AddScoped<IJobPlaceIdRepository, JobPlaceIdRepository>();
            services.AddScoped<IJobPlaceIDServiecs, JobPlaceIdService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDealerRepository, DealerRepository>();
            services.AddControllers()
                .AddFluentValidation(s =>
                {
                    s.RegisterValidatorsFromAssemblyContaining<Startup>();
                    s.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Open API Swagger",
                    Description = "Use api for repman",
                });
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Open API  V1");
            });
        }
    }
}
