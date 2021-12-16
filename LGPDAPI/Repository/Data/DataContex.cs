using LGPD.Modal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Repository.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Processo> Processos { get; set; }
        public DbSet<Dados> Dados { get; set; }

        public DbSet<DataMapping> DataMappings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=ProjetoLGPD;User ID =sa; Password=123456;Persist Security Info=True;MultipleActiveResultSets=True");
        }
    }
}
