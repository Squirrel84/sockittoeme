using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });


            string connectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRING");
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = this.Configuration.GetConnectionString("ConnStr");
            }

            ConnectionFactory connectionFactory = new SqlConnectionFactory(connectionString);

            services.AddScoped<ISockRepository>(use => new SockRepository(connectionFactory));

            services.AddScoped<ISockProvider, SockProvider>();

            services.AddScoped<SockController, SockController>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors("AllowAll");
        }
    }
}
