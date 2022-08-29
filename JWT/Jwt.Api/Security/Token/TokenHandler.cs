using Jwt.Api.Domain.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Jwt.Api.Security.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly TokenOptions _options;
        public TokenHandler(IOptions<TokenOptions> tokenOptions)
        {
            _options = tokenOptions.Value;
        }

        public AccessToken CreateAccessToken(User user)
        {
            var accessTokenExpration = DateTime.Now.AddMinutes(_options.AccessTokenExpration);
            var securityKey = SignHandle.GetSecurityKey(_options.SecurityKey);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jst = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                expires: accessTokenExpration,
                notBefore: DateTime.Now,
                claims: GetClaim(user),
                signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jst);

            AccessToken accessToken = new AccessToken
            {
                Token = token,
                Expration = accessTokenExpration,
                RefreshToken = CreateRefreshToken()
            };

            return accessToken;
        }

        public void RevokeRefreshToken(User user)
        {
            user.RefreshToken = null;
        }

        private IEnumerable<Claim> GetClaim(User user)
        {
            var claims = new List<Claim>() {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email,user.Email),
            new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            return claims;
        }

        private string CreateRefreshToken()
        {
            var number = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
}
