 
using Microsoft.Extensions.DependencyInjection; 
using Model.Crud.NetCore.Application.Services;
using Model.Crud.NetCore.Data.Repository;
using Model.Crud.NetCore.Domain.Interface.Repository;
using Model.Crud.NetCore.Domain.Interface.Services;

namespace Model.Crud.NetCore.API.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigurarDependencias(this IServiceCollection services)
        {
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IClienteRepository, ClienteRepository>(); 

            return services;
        }
    }
}