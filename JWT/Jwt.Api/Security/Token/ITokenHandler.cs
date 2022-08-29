using Jwt.Api.Domain.Model;

namespace Jwt.Api.Security.Token
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);
        void RevokeRefreshToken(User user);
    }
}
