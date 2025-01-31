using Compras.Models;
using Microsoft.EntityFrameworkCore;

namespace Compras.Infra
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-84UMQCT\SQLEXPRESS; initial catalog = ComprasSite; Integrated Security = true; TrustServerCertificate = true;");
            }
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
    }
}