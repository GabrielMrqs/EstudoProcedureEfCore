using Estudo.Domain.Shared;

namespace Estudo.Domain.Products
{
    public class Product : Entity
    {
        public Product()
        {

        }
        public double Price { get; set; }
        public string? Name { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
