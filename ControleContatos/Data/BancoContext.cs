using ControleClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleClientes.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }

    }
}
