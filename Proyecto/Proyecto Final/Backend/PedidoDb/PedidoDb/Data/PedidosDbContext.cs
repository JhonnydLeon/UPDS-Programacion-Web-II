using Microsoft.EntityFrameworkCore;
using PedidoDb.Modelos;

namespace PedidoDb.Data
{
    public class PedidosDbContext : DbContext
    {
        public PedidosDbContext(DbContextOptions<PedidosDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración adicional (si es necesaria)
        }
    }
}
