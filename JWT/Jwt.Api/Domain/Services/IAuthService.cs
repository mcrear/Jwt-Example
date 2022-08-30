using Jwt.Api.Domain.Response;

namespace Jwt.Api.Domain.Services
{
    public interface IAuthService
    {
        Task<AccessTokenResponse> CreateAccessToken(string email, string password);
        Task<AccessTokenResponse> CreateAccessTokenByRefreshToken(string refreshToken);
        Task<AccessTokenResponse> RevokeRefreshToken(string refreshToken);

    }
}
