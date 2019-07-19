using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SockItToeMe.API.Controllers;
using SockItToeMe.Application;
using SockItToeMe.Core;
using SockItToeMe.Core.Sql;
using SockItToeMe.DataAccess;

namespace SockItToeMe.API
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
            services.AddApiVersioning(options => {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1,0);
                options.ApiVersionReader = new HeaderApiVersionReader("api-version");
                options.UseApiBehavior = true;
                options.ReportApiVersions = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            string connectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRING");
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = this.Configuration.GetConnectionString("ConnStr");
            }

            ConnectionFactory connectionFactory = new SqlConnectionFactory(connectionString);

            services.AddScoped<ISockRepository>(use => new SockRepository(connectionFactory));
            services.AddScoped<ISizeRepository>(use => new SizeRepository(connectionFactory));
            services.AddScoped<IThicknessRepository>(use => new ThicknessRepository(connectionFactory));
            services.AddScoped<IMaterialRepository>(use => new MaterialRepository(connectionFactory));

            services.AddScoped<ISockProvider, SockProvider>();
            services.AddScoped<ISizeProvider, SizeProvider>();
            services.AddScoped<IThicknessProvider, ThicknessProvider>();
            services.AddScoped<IMaterialProvider, MaterialProvider>();

            services.AddScoped<SockController, SockController>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseMvc();
        }
    }
}
