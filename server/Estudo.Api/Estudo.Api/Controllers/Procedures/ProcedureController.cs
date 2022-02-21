using Estudo.Infra.Procedures.ClientsAndProducts;
using Estudo.Domain.Procedures;
using Microsoft.AspNetCore.Mvc;

namespace Estudo.Api.Controllers.Procedures
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private readonly ClientAndProductsRepository _clientAndProductsRepository;

        public ProcedureController(ClientAndProductsRepository clientAndProductsRepository)
        {
            _clientAndProductsRepository = clientAndProductsRepository;
        }

        [HttpGet]
        [Route("GetProductsAndClients")]
        public async Task<ClientAndProducts> GetAll()
        {
            return await _clientAndProductsRepository.GetClientAndProductsAsync();
        }
    }
}