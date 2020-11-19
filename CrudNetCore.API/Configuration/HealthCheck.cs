using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Model.Crud.NetCore.API.Configuration
{
    public static class HealthCheck
    {

        public static IServiceCollection ConfigurarHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddHealthChecks()
            .AddSqlServer(configuration.GetConnectionString("ModelDB"));

            return services;
        }

    }
}