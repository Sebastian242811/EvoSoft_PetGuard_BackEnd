using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PetGuard.Domain.Persistence.Contexts;
using PetGuard.Domain.Repositories;
using PetGuard.Domain.Services;
using PetGuard.Extensions;
using PetGuard.Persistence.Repositories;
using PetGuard.Services;

namespace PetGuard
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

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("Petguard-api-in-memory");
            });

            //Unit Of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();


            //Services
            services.AddScoped<IUserService, UserService>();



            services.AddAutoMapper(typeof(Startup));

            services.AddCustomSwagger();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCustomSwagger();
        }
    }
}
