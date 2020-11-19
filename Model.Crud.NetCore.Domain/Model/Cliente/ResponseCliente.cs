using Newtonsoft.Json;
using System;

namespace Model.Crud.NetCore.Domain.Model
{
    public class ResponseCliente
    { 
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
