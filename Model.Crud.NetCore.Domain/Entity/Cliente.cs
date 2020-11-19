using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Crud.NetCore.Domain.Entity
{
    [Dapper.Contrib.Extensions.Table("TbCliente")]
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
