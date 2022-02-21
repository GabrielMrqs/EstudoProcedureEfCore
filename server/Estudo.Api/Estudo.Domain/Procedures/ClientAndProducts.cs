using Estudo.Domain.Clients;
using Estudo.Domain.Products;
using Estudo.Domain.Shared;

namespace Estudo.Domain.Procedures
{
    public class ClientAndProducts : Entity
    {
        public IEnumerable<Product>? Products { get; set; }
        public IEnumerable<Client>? Clients { get; set; }
    }
}
