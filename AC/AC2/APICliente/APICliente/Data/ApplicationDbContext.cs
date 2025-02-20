
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using APICliente.Modelos;

namespace APICliente.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):
            base(options)
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
