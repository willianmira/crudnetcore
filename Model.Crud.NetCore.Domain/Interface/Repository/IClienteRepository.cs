using Model.Crud.NetCore.Domain.Entity;
using System;
using System.Collections.Generic; 
using System.Threading.Tasks;

namespace Model.Crud.NetCore.Domain.Interface.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> Post(Cliente entity);

        Task<Cliente> Put(Cliente entity);

        Task<Cliente> Delete(Cliente entity);

        Task<Cliente> Get(Guid Id);

        Task<IEnumerable<Cliente>> GetAll();
    }
}
