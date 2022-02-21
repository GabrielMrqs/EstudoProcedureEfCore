using Estudo.Domain.Shared;

namespace Estudo.Domain.Clients
{
    public class Client : Entity
    {
        public Client()
        {
        }

        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
