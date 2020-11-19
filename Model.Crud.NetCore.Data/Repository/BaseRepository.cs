using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Model.Crud.NetCore.Data.Repository
{
    public class BaseRepository
    {
        private readonly IConfiguration _configuration;

        public BaseRepository(IConfiguration configuration) => 
            _configuration = configuration;

        protected string ObterConexao
        {
            get { return _configuration.GetConnectionString("ModelDB"); }
        }

        protected IDbConnection OpenConn() =>
             new SqlConnection(ObterConexao);
        
    }
}
