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
    public class ChatController : ControllerBase
    {
        public readonly IChatService _chatService;
        public readonly IMapper _mapper;

        public ChatController(IMapper mapper, IChatService chatService)
        {
            _mapper = mapper;
            _chatService = chatService;
        }



        // GET: api/<ChatController>
        [HttpGet]
        public async Task<IEnumerable<ChatResource>> GetAllAsync()
        {
            var cities = await _chatService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Chat>, IEnumerable<ChatResource>>(cities);

            return resource;
        }

        // GET api/<ChatController>/5
        [HttpGet("{id}")]
        public async Task<ChatResource> Getcitybyid(int id)
        {
            var cities = await _chatService.FindChatById(id);
            var Chatre = cities.Resource;
            var resource = _mapper.Map<Chat, ChatResource>(Chatre);

            return resource;
        }

        // POST api/<ChatController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveChatResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var chat = _mapper.Map<SaveChatResource, Chat>(resource);
            // TODO: Implement Response Logic
            var result = await _chatService.SaveAsync(chat);

            if (!result.Succes)
                return BadRequest(result.Message);

            var ChatResource = _mapper.Map<Chat, ChatResource>(result.Resource);

            return Ok(ChatResource);
        }

        // DELETE api/<ChatController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _chatService.DeleteAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);

            return Ok("Delete");
        }
    }
}
