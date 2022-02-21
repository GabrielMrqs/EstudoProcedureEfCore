using Estudo.Infra.Shared;
using Estudo.Domain.Clients;
using Estudo.Domain.Procedures;
using Estudo.Domain.Products;
using System.Data.Common;

namespace Estudo.Infra.Procedures.ClientsAndProducts
{
    public class ClientAndProductsRepository : BaseRepository<ClientAndProducts>
    {
        public ClientAndProductsRepository(Context context) : base(context)
        {

        }

        public async Task<ClientAndProducts> GetClientAndProductsAsync()
        {
            return await ExecuteReaderAsync(DataMapper, "[dbo].[GetAllClientsAndProducts]");
        }

        public ClientAndProducts DataMapper(DbDataReader dbDataReader)
        {
            return new ClientAndProducts()
            {
                Clients = dbDataReader.Translate<Client>(),
                Products = dbDataReader.Translate<Product>()
            };
        }
    }
}
