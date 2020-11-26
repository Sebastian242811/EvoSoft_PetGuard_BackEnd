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
    public class CardController : ControllerBase
    {
        public readonly ICardService _cardService;
        public readonly IMapper _mapper;

        public CardController(IMapper mapper, ICardService cardService)
        {
            _mapper = mapper;
            _cardService = cardService;
        }

        // GET api/<CardController>/5
        [HttpGet("{id}")]
        public async Task<CardResource> Get(int id)
        {
            var cities = await _cardService.FindCardById(id);
            var Cardre = cities.Resource;
            var resource = _mapper.Map<Card, CardResource>(Cardre);

            return resource;
        }

        // POST api/<CardController>
        [HttpPut]
        public async Task<IActionResult> Put(int id,[FromBody] SaveCardResource value)
        {
            var Card = _mapper.Map<SaveCardResource, Card>(value);
            var result = await _cardService.UpdateAsync(id, Card);

            if (result == null)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Card, CardResource>(result.Resource);
            return Ok(categoryResource);
        }

        // DELETE api/<CardController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cardService.DeleteAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);

            return Ok("Delete");
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCardResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var chat = _mapper.Map<SaveCardResource, Card>(resource);
            // TODO: Implement Response Logic
            var result = await _cardService.SaveAsync(chat);

            if (!result.Succes)
                return BadRequest(result.Message);

            var CardResource = _mapper.Map<Card, CardResource>(result.Resource);

            return Ok(CardResource);
        }
    }
}
