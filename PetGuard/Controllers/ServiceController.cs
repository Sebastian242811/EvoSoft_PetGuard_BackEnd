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
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly IPetKeeperService _petKeeperService;
        private readonly IMapper _mapper;

        public ServiceController(IServiceService serviceService, IPetKeeperService petKeeperService, IMapper mapper)
        {
            _serviceService = serviceService;
            _petKeeperService = petKeeperService;
            _mapper = mapper;
        }

        [SwaggerOperation(
             Summary = "List all services",
             Description = "List of services",
             OperationId = "ListAllServices",
             Tags = new[] { "Service" }
             )]
        [SwaggerResponse(200, "List of Services", typeof(IEnumerable<ServiceResource>))]
        [ProducesResponseType(typeof(IEnumerable<ServiceResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<ServiceResource>> GetAllAsync()
        {
            var services = await _serviceService.ListAsync();
            var resource = _mapper
                .Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(services);
            return resource;
        }

        [SwaggerOperation(
            Summary = "Create a Service",
            Description = "Create a Service",
            OperationId = "CreateService",
            Tags = new[] { "Service" }
        )]
        [SwaggerResponse(200, "Service was created", typeof(ServiceResource))]
        [HttpPost("{clientId}/{petKeeperId}")]
        public async Task<IActionResult> PostAsync(SaveServiceResource resource, int clientId, int petKeeperId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var services = _mapper.Map<SaveServiceResource, Service>(resource);

            var result = await _serviceService.SaveAsync(services, clientId, petKeeperId);

            if (!result.Succes)
                return BadRequest(result.Message);
            var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);
            return Ok(serviceResource);
        }

        [SwaggerOperation(
           Summary = "Update a Service",
           Description = "Update a Service",
           OperationId = "UpdateService",
           Tags = new[] { "Service" }
       )]
        [SwaggerResponse(200, "Service was updated", typeof(ServiceResource))]
        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveServiceResource resource)
        {
            var services = _mapper.Map<SaveServiceResource, Service>(resource);
            var result = await _serviceService.UpdateAsync(id, services);
            if (!result.Succes)
                return BadRequest(result.Message);
            var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);
            return Ok(serviceResource);
        }

        [SwaggerOperation(
            Summary = "Delete a Service",
            Description = "Delete a Service",
            OperationId = "DeleteService",
            Tags = new[] { "Service" }
        )]
        [SwaggerResponse(200, "Service was delete", typeof(ServiceResource))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _serviceService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);
            return Ok(serviceResource);
        }
    }
}
