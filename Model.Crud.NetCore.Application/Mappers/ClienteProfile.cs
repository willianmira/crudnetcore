using AutoMapper;
using Model.Crud.NetCore.Domain.Entity;
using Model.Crud.NetCore.Domain.Model;

namespace Model.Crud.NetCore.Application.Services
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ResponseCliente>();

            CreateMap<RequestCliente, Cliente>(); 
        }
    }
}
