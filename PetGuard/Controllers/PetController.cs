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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetGuard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IMapper _mapper;

        public PetController(IMapper mapper, IPetService petService)
        {
            _mapper = mapper;
            _petService = petService;
        }



        // GET: api/<PetController>
        [HttpGet]
        public async Task<IEnumerable<PetResource>> GetAllAsync()
        {
            var cities = await _petService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Pet>, IEnumerable<PetResource>>(cities);

            return resource;
        }

        // GET api/<PetController>/5
        [HttpGet("{id}")]
        public async Task<PetResource> Getcitybyid(int id)
        {
            var cities = await _petService.FindPetById(id);
            var Petre = cities.Resource;
            var resource = _mapper.Map<Pet, PetResource>(Petre);

            return resource;
        }

        // POST api/<PetController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePetResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var Pet = _mapper.Map<SavePetResource, Pet>(resource);
            // TODO: Implement Response Logic
            var result = await _petService.SaveAsync(Pet);

            if (!result.Succes)
                return BadRequest(result.Message);

            var PetResource = _mapper.Map<Pet, PetResource>(result.Resource);

            return Ok(PetResource);
        }

        // PUT api/<PetController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePetResource resource)
        {
            var Pet = _mapper.Map<SavePetResource, Pet>(resource);
            var result = await _petService.UpdateAsync(id, Pet);

            if (result == null)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Pet, PetResource>(result.Resource);
            return Ok(categoryResource);
        }

        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _petService.DeleteAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);

            return Ok("Delete");
        }
    }
}
