using Estudo.Infra.Clients;
using Estudo.Domain.Clients;
using Microsoft.AspNetCore.Mvc;

namespace Estudo.Api.Controllers.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientRepository _clientRepository;

        public ClientController(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Client?> GetById(Guid id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _clientRepository.GetAllAsync();
        }
    }
}
