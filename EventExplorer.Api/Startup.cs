using AutoMapper;
using EventExplorer.Api.Persistence;
using EventExplorer.Api.Persistence.Repositories;
using EventExplorer.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EventExplorer.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CORS", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                });
            });

            services.AddControllers();

            services.AddAutoMapper();

            services.AddScoped<AttendanceService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<EventService>();
            services.AddScoped<LocationService>();
            services.AddScoped<OrganizerService>();
            services.AddScoped<UserService>();

            services.AddScoped<AttendanceRepository>();
            services.AddScoped<CategoryRepository>();
            services.AddScoped<LocationRepository>();
            services.AddScoped<EventRepository>();
            services.AddScoped<OrganizerRepository>();
            services.AddScoped<UserRepository>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(_configuration.GetConnectionString("Local")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EventExplorer.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventExplorer.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CORS");

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
