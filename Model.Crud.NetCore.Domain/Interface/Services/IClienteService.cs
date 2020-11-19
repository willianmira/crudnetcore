using Model.Crud.NetCore.Domain.Model;
using System;
using System.Collections.Generic; 
using System.Threading.Tasks;

namespace Model.Crud.NetCore.Domain.Interface.Services
{
    public interface IClienteService
    {
        Task<BaseResponse> Post(RequestCliente model);

        Task<BaseResponse> Put(RequestCliente model);

        Task<BaseResponse> Delete(Guid Id);

        Task<BaseResponse> Get(Guid Id);

        Task<BaseResponse> GetAll();
    }
}
