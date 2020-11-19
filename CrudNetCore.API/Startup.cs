using AutoMapper;
using FluentValidation.AspNetCore; 
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model.Crud.NetCore.API.Configuration;
using Model.Crud.NetCore.API.DataContext;
using System; 

namespace CrudNetCore.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(opt =>
            {
                opt.AllowEmptyInputInBodyModelBinding = true;
                opt.EnableEndpointRouting = false;
            })
            .ConfigureApiBehaviorOptions(opt => opt.SuppressMapClientErrors = true)
            .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddDbContext<CrudContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ModelDB")); 
            });
              

            services.AddOptions();

            // automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // configurar dependencias
            services.ConfigurarDependencias();

            // swagger
            services.ConfigurarSwagger();

            // Health Check 
            services.ConfigurarHealthChecks(Configuration);

            // serilog
            services.ImplementLogConfigurationService(Configuration);

            services.AddHttpContextAccessor(); 
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, CrudContext db)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
            });

           // db.Database.EnsureCreated();

            app.UtilizarConfiguracaoSwagger();
            app.UseMvcWithDefaultRoute();
        }
    }
}