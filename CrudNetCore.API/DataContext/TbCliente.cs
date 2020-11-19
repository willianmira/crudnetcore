using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace Model.Crud.NetCore.API.DataContext
{
    [Table("TbCliente")]
    public class TbCliente
    {
        [Column("Id")]
        [Key]
        public Guid Id { get; set; }
        [Column("Nome")]
        [StringLength(100)]
        public string Nome { get; set; }
        [Column("Idade")]
        public int Idade { get; set; }
    }
}
