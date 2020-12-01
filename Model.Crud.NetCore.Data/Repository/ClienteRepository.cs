using Microsoft.Extensions.Configuration; 
using Model.Crud.NetCore.Domain.Interface.Repository;
using Dapper.Contrib.Extensions;  
using Model.Crud.NetCore.Domain.Entity;
using System.Threading.Tasks;
using System; 
using System.Collections.Generic;
using Dapper;

namespace Model.Crud.NetCore.Data.Repository
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        public ClienteRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Cliente> Post(Cliente entity)
        {
            var query = @"INSERT INTO  TbCliente (Id, Nome, Idade) values ( @Id, @Nome, @Idade);";
            using (var conn = OpenConn())
            {
                await conn.ExecuteScalarAsync<int>(query, new
                {
                    entity.Id,
                    entity.Nome,
                    entity.Idade
                });

                return entity; 
            } 
        }

        public async Task<Cliente> Put(Cliente entity)
        {
            using (var conn = OpenConn())
            { 
                await conn.UpdateAsync<Cliente>(entity);
            }

            return entity;
        }

        public async Task<Cliente> Delete(Cliente entity)
        {
            using (var conn = OpenConn())
            {
                await conn.DeleteAsync<Cliente>(entity);
            }

            return entity;
        }

        public async Task<Cliente> Get(Guid Id)
        { 
            using (var conn = OpenConn())
            {
                return await conn.GetAsync<Cliente>(Id);
            } 
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        { 
            using (var conn = OpenConn())
            {
                return await conn.GetAllAsync<Cliente>();
            } 
        }
    }
}
