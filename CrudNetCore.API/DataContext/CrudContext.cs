using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Crud.NetCore.API.DataContext
{
    public class CrudContext : DbContext
    {
        public DbSet<TbCliente> Clientes { get; set; }

        public CrudContext(DbContextOptions<CrudContext> options) : base(options) {
        }
         
    }
}

