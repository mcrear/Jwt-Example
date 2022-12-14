using AutoMapper;
using Jwt.Api.Domain.Model;
using Jwt.Api.Domain.Repositories;
using Jwt.Api.Domain.Services;
using Jwt.Api.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Jwt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        //private readonly IDataProtector _protector;

        public UserController(IUserService userService, IMapper mapper/*, IDataProtectionProvider protectionProvider*/)
        {
            _userService = userService;
            _mapper = mapper;
          //  _protector = protectionProvider.CreateProtector(nameof(ControllerBase));
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            IEnumerable<Claim> claims = User.Claims;

            if (claims == null)
                return Unauthorized();

            string userId = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;
            var user = await _userService.GetUserById(int.Parse(userId));

            if (user == null)
                return NotFound();
            if (!user.Success)
                return BadRequest();

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddUser(UserResource user)
        {
            User usr = _mapper.Map<UserResource, User>(user);
           // usr.Password = _protector.Protect(user.Password);
            var res = await _userService.Add(usr);

            if (res.Success)
                return Ok(res.Data);

            return BadRequest(res.Message);
        }
    }
}
