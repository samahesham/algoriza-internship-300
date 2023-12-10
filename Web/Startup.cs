using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.SqlServer; // Add this line
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using WebApplication9.Infrastructure;

namespace WebApplication9.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<YourDbContext>(Options => Options.UseSqlServer(_configuration.GetConnectionString("DESKTOP-VILLPCT\\MSSQLSERVER01")));
            var connectionString = _configuration.GetConnectionString("DESKTOP-VILLPCT\\MSSQLSERVER01");
            services.AddDbContext<YourDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication9", Version = "v1" });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication9", Version = "v1" });
            });
            // Register your repositories and services
            services.AddScoped<YourDbContext>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IPatientService, PatientService>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication9");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
