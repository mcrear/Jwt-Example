using Jwt.Api.Domain.Model;
using Jwt.Api.Security.Token;

namespace Jwt.Api.Domain.Response
{
    public class AccessTokenResponse : BaseResponse<AccessToken>
    {
        public AccessTokenResponse(AccessToken accessToken) : base(accessToken)
        {

        }
        public AccessTokenResponse(string message) : base(message)
        {

        }
    }
}
