using Estudo.Infra.Shared;
using Estudo.Domain.Products;

namespace Estudo.Infra.Products
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(Context context) : base(context)
        {

        }
    }
}
