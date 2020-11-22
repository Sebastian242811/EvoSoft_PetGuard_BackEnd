using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetGuard.Domain.Models;
using PetGuard.Domain.Services;
using PetGuard.Resources;
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
            Summary = "Assign Service",
            Description = "Assign Service",
            OperationId = "AssignService",
            Tags = new[] { "Service" }
        )]
        [SwaggerResponse(200, "Service was created", typeof(ServiceResource))]
        [HttpPost("{clientId}/{petKeeperId}")]
        public async Task<IActionResult> AssignUserChef(int clientId, int petKeeperId)
        {
            var result = await _serviceService.AssignServiceAsync(clientId, petKeeperId);
            if (!result.Succes)
                return BadRequest(result.Message);
            PetKeeper petKeeper = _petKeeperService.GetByIdAsync(petKeeperId).Result.Resource;
            var resource = _mapper.Map<PetKeeper, ServiceResource>(petKeeper);
            return Ok(resource);
        }
    }
}
