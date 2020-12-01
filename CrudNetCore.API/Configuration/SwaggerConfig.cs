using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models; 
using System; 
using System.IO;
using System.Reflection;

namespace Model.Crud.NetCore.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection ConfigurarSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Model Crud Cliente",
                    Description = "Modelo de cadastro, alteração, exclusão e consulta do cliente",
                    Contact = new OpenApiContact
                    { 
                        Name = "WGM",
                        Email = "wllian.mira@gmail.com"
                    }
                }); 

            });

            return services;
        }

        public static IApplicationBuilder UtilizarConfiguracaoSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Model Crud Cliente"); 
                c.DefaultModelsExpandDepth(-1);
            });
            return app;
        }
    }
}