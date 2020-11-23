using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetGuard.Domain.Models;
using PetGuard.Domain.Services;
using PetGuard.Extensions;
using PetGuard.Resources;
using PetGuard.Resources.Saves;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetGuard.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [SwaggerOperation(
             Summary = "List all clients",
             Description = "List of clients",
             OperationId = "ListAllClients",
             Tags = new[] { "Clients" }
             )]
        [SwaggerResponse(200, "List of Clients", typeof(IEnumerable<ClientResource>))]
        [ProducesResponseType(typeof(IEnumerable<ClientResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<ClientResource>> GetAllAsync()
        {
            var clients = await _clientService.ListAsync();
            var resource = _mapper
                .Map<IEnumerable<Client>, IEnumerable<ClientResource>>(clients);
            return resource;
        }

        [SwaggerOperation(
            Summary = "List all by Client Name",
            Description = "List by Client Name",
            OperationId = "ListAllByClientName",
            Tags = new[] { "Clients" }
        )]
        [SwaggerResponse(200, "List of clients by name", typeof(ClientResource))]
        [ProducesResponseType(typeof(IEnumerable<ClientResource>), 200)]
        [HttpGet("name/{name}")]
        public async Task<IEnumerable<ClientResource>> GetAllByName(string name)
        {
            var clients = await _clientService.GetByNameAsync(name);
            var resource = _mapper
                .Map<IEnumerable<Client>, IEnumerable<ClientResource>>(clients);
            return resource;
        }

        [SwaggerOperation(
            Summary = "List all by Clients Email",
            Description = "List by Clients Email",
            OperationId = "ListAllByClientsEmail",
            Tags = new[] { "Clients" }
        )]
        [SwaggerResponse(200, "List of clients by email", typeof(ClientResource))]
        [HttpGet("email")]
        public async Task<IActionResult> GetClientByEmail(string email)
        {
            var result = await _clientService.GetByEmailAsync(email);

            if (!result.Succes)
                return BadRequest(result.Message);
            var resource = _mapper.Map<Client, ClientResource>(result.Resource);
            return Ok(resource);
        }

        [SwaggerOperation(
            Summary = "List all by Clients Lastname",
            Description = "List by Clients Lastname",
            OperationId = "ListAllByClientsLastname",
            Tags = new[] { "Clients" }
        )]
        [SwaggerResponse(200, "List of clients by lastname", typeof(ClientResource))]
        [ProducesResponseType(typeof(IEnumerable<ClientResource>), 200)]
        [HttpGet("lastname/{lastname}")]
        public async Task<IEnumerable<ClientResource>> GetAllByLastname(string lastname)
        {
            var clients = await _clientService.GetByLastNameAsync(lastname);
            var resource = _mapper
                .Map<IEnumerable<Client>, IEnumerable<ClientResource>>(clients);
            return resource;
        }


        [SwaggerOperation(
            Summary = "Create a Client",
            Description = "Create a Client",
            OperationId = "CreateClient",
            Tags = new[] { "Client" }
        )]
        [SwaggerResponse(200, "Client was created", typeof(ClientResource))]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveClientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var clients = _mapper.Map<SaveClientResource, Client>(resource);

            var result = await _clientService.SaveAsync(clients);

            if (!result.Succes)
                return BadRequest(result.Message);
            var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
            return Ok(clientResource);
        }
        [SwaggerOperation(
           Summary = "Update a Client",
           Description = "Update a Client",
           OperationId = "UpdateClient",
           Tags = new[] { "Client" }
       )]
        [SwaggerResponse(200, "Client was updated", typeof(ClientResource))]
        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveClientResource resource)
        {
            var clients = _mapper.Map<SaveClientResource, Client>(resource);
            var result = await _clientService.UpdateAsync(id, clients);
            if (!result.Succes)
                return BadRequest(result.Message);
            var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
            return Ok(clientResource);
        }

        [SwaggerOperation(
            Summary = "Delete a Client",
            Description = "Delete a Client",
            OperationId = "DeleteClient",
            Tags = new[] { "Client" }
        )]
        [SwaggerResponse(200, "Client was delete", typeof(ClientResource))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _clientService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
            return Ok(clientResource);
        }
    }
}
