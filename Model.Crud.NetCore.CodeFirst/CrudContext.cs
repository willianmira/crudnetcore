using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Crud.NetCore.CodeFirst
{
    public class CrudContext : DbContext
    {
        public DbSet<TbCliente> Cliente { get; set; }

        public CrudContext(DbContextOptions<CrudContext> options) : base(options) {
        }
         
        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TbCliente>().ToTable("TbCliente");
        }

        [Table("TbCliente")]
        public class TbCliente
        {
            [Column("Id")]
            [Key] 
            public Guid Id { get; set; }
            [Column("Nome")]
            public string Nome { get; set; }
            [Column("Idade")]
            public int Idade { get; set; }
        }
    }
}

