namespace Hogwarts.WebApp
{
    using AutoMapper;
    using Hogwarts.Application.Automapper;
    using Hogwarts.Application.Services;
    using Hogwarts.Application.Services.Implementations;
    using Hogwarts.Domain.Repositories;
    using Hogwarts.Infrastructure.Data;
    using Hogwarts.Infrastructure.Repositories;
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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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

            #region DBContext

            var connectionString = Configuration.GetConnectionString("cnnString");
            services.AddDbContext<HogwartsContext>(options =>
                   options.UseSqlServer(connectionString, o => o.MigrationsAssembly("Hogwarts.WebApp")));
            #endregion

            #region Services
            services.AddTransient<IStudentService, StudentService>();
            #endregion

            #region Repositories
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IHouseRepository, HouseRepository>();
            #endregion

            #region Automapper

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new OrganizationProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hogwarts.WebApp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, HogwartsContext dbContext)
        {
            DatabaseInitializer.Initialize(dbContext);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hogwarts.WebApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
