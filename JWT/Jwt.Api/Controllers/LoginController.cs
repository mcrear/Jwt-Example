using Jwt.Api.Domain.Services;
using Jwt.Api.Extensions;
using Jwt.Api.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> AccessToken(LoginResource login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var token = await _authService.CreateAccessToken(login.Email, login.Password);
            if (!token.Success)
                return NotFound(token.Message);

            return Ok(token.Data);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(TokenResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var token = await _authService.CreateAccessTokenByRefreshToken(resource.RefreshToken);
            if (!token.Success)
                return NotFound(token.Message);

            return Ok(token.Data);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(TokenResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var token = await _authService.RevokeRefreshToken(resource.RefreshToken);
            if (!token.Success)
                return NotFound(token.Message);

            return Ok(token.Data);
        }
    }
}
