using Estudo.Infra.Shared;
using Estudo.Domain.Clients;

namespace Estudo.Infra.Clients
{
    public class ClientRepository : BaseRepository<Client>
    {
        public ClientRepository(Context context) : base(context)
        {

        }
    }
}
