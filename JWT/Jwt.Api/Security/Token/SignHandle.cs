using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Jwt.Api.Security.Token
{
    public static class SignHandle
    {
        public static SecurityKey GetSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
