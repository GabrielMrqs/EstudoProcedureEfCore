using Estudo.Domain.Clients;
using Estudo.Domain.Procedures;
using Estudo.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Estudo.Infra
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        DbSet<Client>? Clients { get; set; }
        DbSet<Product>? Products { get; set; }
        DbSet<ClientAndProducts>? ClientAndProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}