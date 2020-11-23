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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all by Users Email",
            Description = "List by Users Email",
            OperationId = "ListAllByUsersEmail",
            Tags = new[] { "Users" }
        )]
        [SwaggerResponse(200, "List of users by email", typeof(UserResource))]
        [HttpGet("email")]
        public async Task<IActionResult> GetUserChefByEmail(string email)
        {
            var result = await _userService.GetByEmailAsync(email);

            if (!result.Succes)
                return BadRequest(result.Message);
            var resource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(resource);
        }
    }
}
