using Jwt.Api.Domain.Response;
using Jwt.Api.Domain.Services;
using Jwt.Api.Security.Token;

namespace Jwt.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;

        public AuthService(IUserService userService, ITokenHandler tokenHandler)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
        }

        public async Task<AccessTokenResponse> CreateAccessToken(string email, string password)
        {
            var userRes = await _userService.GetUseryByEmailAndPassword(email, password);

            if (!userRes.Success)
                return new AccessTokenResponse(userRes.Message);

            if (userRes.Data.RefreshTokenEndDate < DateTime.Now)
                return new AccessTokenResponse("Refresh token süresi sona ermiştir.");

            var token = _tokenHandler.CreateAccessToken(userRes.Data);
            await _userService.SaveRefreshToken(userRes.Data.Id, token.RefreshToken);

            return new AccessTokenResponse(token);
        }

        public async Task<AccessTokenResponse> CreateAccessTokenByRefreshToken(string refreshToken)
        {
            var userRes = await _userService.GetUserByRefreshToken(refreshToken);

            if (!userRes.Success)
                return new AccessTokenResponse(userRes.Message);

            var token = _tokenHandler.CreateAccessToken(userRes.Data);
            await _userService.SaveRefreshToken(userRes.Data.Id, token.RefreshToken);

            return new AccessTokenResponse(token);
        }

        public async Task<AccessTokenResponse> RevokeRefreshToken(string refreshToken)
        {
            var userRes = await _userService.GetUserByRefreshToken(refreshToken);

            if (!userRes.Success)
                return new AccessTokenResponse(userRes.Message);

            await _userService.RemoveRefreshTokenAsync(userRes.Data);

            return new AccessTokenResponse(new AccessToken());
        }
    }
}
