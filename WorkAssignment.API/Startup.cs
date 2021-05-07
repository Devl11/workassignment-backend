using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OpenChargeApiClient;
using WorkAssignment.API.Mappers;
using WorkAssignment.Shared;
using AutoMapper;
using Hangfire;
using Newtonsoft.Json;
using WorkAssignment.API.Services;
using WorkAssignment.Migrations;

namespace WorkAssignment.API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        
        public Startup (IConfiguration configuration) {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = new AppSettings(_configuration);
            services.Configure<AppSettings>(appSettings.AppSettingsSection);
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WorkAssignment", Version = "v1" });
            });
            
            services.AddScoped<IChargerService, ChargerService>();
            
            services.AddDbContext<WorkDbContext>(options => options.UseInMemoryDatabase(databaseName: "WorkAssignment"));
            services.AddAutoMapper(typeof(ChargersMappingProfiles));
            services.AddOpenChargeServices(appSettings);
            services.AddHangfire(c => c.UseInMemoryStorage());
            services.AddHangfireServer();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();  
                app.UseSwaggerUI(c =>  
                {  
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");  
                }); 
            }
            app.UseCors(
                options => options.WithOrigins("http://localhost:3000").AllowAnyMethod()
            );

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}