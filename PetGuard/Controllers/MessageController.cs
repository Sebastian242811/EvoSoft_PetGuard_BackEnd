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
    public class MessageController : ControllerBase
    {
        public readonly IMessageService _messageService;
        public readonly IMapper _mapper;

        public MessageController(IMapper mapper, IMessageService messageService)
        {
            _mapper = mapper;
            _messageService = messageService;
        }



        // GET: api/<MessageController>
        [HttpGet]
        public async Task<IEnumerable<MessageResource>> GetAllAsync()
        {
            var cities = await _messageService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Message>, IEnumerable<MessageResource>>(cities);

            return resource;
        }

        [HttpGet("chat/{id}")]
        public async Task<IEnumerable<MessageResource>> GetAllmessagesofchatAsync(int id)
        {
            var cities = await _messageService.ListMessagesbyChatIdAsync(id);
            var resource = _mapper.Map<IEnumerable<Message>, IEnumerable<MessageResource>>(cities);

            return resource;
        }

        // POST api/<MessageController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMessageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var Message = _mapper.Map<SaveMessageResource, Message>(resource);
            // TODO: Implement Response Logic
            var result = await _messageService.SaveAsync(Message);

            if (!result.Succes)
                return BadRequest(result.Message);

            var MessageResource = _mapper.Map<Message, MessageResource>(result.Resource);

            return Ok(MessageResource);
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _messageService.DeleteAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);

            return Ok("Delete");
        }
    }
}
