using AutoMapper;
using Jwt.Api.Domain.Services;
using Jwt.Api.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetUser()
        {
            return Ok();
        }

        public async Task<IActionResult> AddUser(UserResource user)
        {
            return Ok(user);
        }
    }
}
