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
    public class PetKeeperController : ControllerBase
    {
        private readonly IPetKeeperService _petKeeperService;
        private readonly IMapper _mapper;

        public PetKeeperController(IPetKeeperService petKeeperService, IMapper mapper)
        {
            _petKeeperService = petKeeperService;
            _mapper = mapper;
        }

        [SwaggerOperation(
             Summary = "List all pet keepers",
             Description = "List of pet keepers",
             OperationId = "ListAllPetKeepers",
             Tags = new[] { "Pet Keepers" }
             )]
        [SwaggerResponse(200, "List of Pet Keepers", typeof(IEnumerable<PetKeeperResource>))]
        [ProducesResponseType(typeof(IEnumerable<PetKeeperResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<PetKeeperResource>> GetAllAsync()
        {
            var petKeepers = await _petKeeperService.ListAsync();
            var resource = _mapper
                .Map<IEnumerable<PetKeeper>, IEnumerable<PetKeeperResource>>(petKeepers);
            return resource;
        }

        [SwaggerOperation(
            Summary = "List all by Pet Keepers Email",
            Description = "List by Pet Keepers Email",
            OperationId = "ListAllByPetKeepersEmail",
            Tags = new[] { "Pet Keepers" }
        )]
        [SwaggerResponse(200, "List of pet keepers by email", typeof(PetKeeperResource))]
        [HttpGet("email")]
        public async Task<IActionResult> GetPetKeeperByEmail(string email)
        {
            var result = await _petKeeperService.GetByEmailAsync(email);

            if (!result.Succes)
                return BadRequest(result.Message);
            var resource = _mapper.Map<PetKeeper, PetKeeperResource>(result.Resource);
            return Ok(resource);
        }

        [SwaggerOperation(
            Summary = "List all by Pet Keepers Name",
            Description = "List by Pet Keepers name",
            OperationId = "ListAllByPetKeepersName",
            Tags = new[] { "Pet Keepers" }
        )]
        [SwaggerResponse(200, "List of pet keepers by first name", typeof(PetKeeperResource))]
        [HttpGet("name/{name}")]
        public async Task<IEnumerable<PetKeeperResource>> GetAllByFirstName(string firstName)
        {
            var petKeepers = await _petKeeperService.GetByFirstNameAsync(firstName);
            var resource = _mapper
                .Map<IEnumerable<PetKeeper>, IEnumerable<PetKeeperResource>>(petKeepers);
            return resource;
        }

        [SwaggerOperation(
            Summary = "List all by Pet Keepers Lastname",
            Description = "List by Pet Keepers Lastname",
            OperationId = "ListAllByPetKeepersLastname",
            Tags = new[] { "Pet Keepers" }
        )]
        [SwaggerResponse(200, "List of pet keepers by last name", typeof(PetKeeperResource))]
        [HttpGet("lastname/{lastname}")]
        public async Task<IEnumerable<PetKeeperResource>> GetAllByLastName(string lastName)
        {
            var petKeepers = await _petKeeperService.GetByLastnameAsync(lastName);
            var resource = _mapper
                .Map<IEnumerable<PetKeeper>, IEnumerable<PetKeeperResource>>(petKeepers);
            return resource;
        }

        [SwaggerOperation(
            Summary = "Save a Pet Keeper",
            Description = "Save a Pet Keeper",
            OperationId = "SavePetKeeper",
            Tags = new[] { "Pet Keepers" }
        )]
        [SwaggerResponse(200, "Pet keeper was saved", typeof(PetKeeperResource))]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePetKeeperResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var petKeeper = _mapper.Map<SavePetKeeperResource, PetKeeper>(resource);

            var result = await _petKeeperService.SaveAsync(petKeeper);

            if (!result.Succes)
                return BadRequest(result.Message);
            var petKeeperResource = _mapper.Map<PetKeeper, PetKeeperResource>(result.Resource);
            return Ok(petKeeperResource);
        }
        [SwaggerOperation(
            Summary = "Update a Pet Keeper",
            Description = "Update a Pet Keeper",
            OperationId = "UpdatePetKeeper",
            Tags = new[] { "Pet Keepers" }
        )]
        [SwaggerResponse(200, "Pet keeper was updated", typeof(PetKeeperResource))]
        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePetKeeperResource resource)
        {
            var petKeeper = _mapper.Map<SavePetKeeperResource, PetKeeper>(resource);
            var result = await _petKeeperService.UpdateAsync(id, petKeeper);
            if (!result.Succes)
                return BadRequest(result.Message);
            var petKeeperResource = _mapper.Map<PetKeeper, PetKeeperResource>(result.Resource);
            return Ok(petKeeperResource);
        }
        [SwaggerOperation(
            Summary = "Delete a Pet Keeper",
            Description = "Delete a Pet Keeper",
            OperationId = "DeletePetKeeper",
            Tags = new[] { "Pet Keepers" }
        )]
        [SwaggerResponse(200, "Pet keeper was delete", typeof(PetKeeperResource))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _petKeeperService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var petKeeperResource = _mapper.Map<PetKeeper, PetKeeperResource>(result.Resource);
            return Ok(petKeeperResource);
        }

    }
}
