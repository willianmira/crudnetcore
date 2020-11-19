using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog; 

namespace Model.Crud.NetCore.API.Configuration
{
    public static class LogConfig
    { 
        public static void ImplementLogConfigurationService(this IServiceCollection services, IConfiguration configuration)
        {

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            services.AddSingleton(Log.Logger);
        }
    }
}