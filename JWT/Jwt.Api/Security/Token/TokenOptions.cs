namespace Jwt.Api.Security.Token
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public long AccessTokenExpration { get; set; }
        public long RefreshTokenExpration { get; set; }
        public string SecurityKey { get; set; }
    }
}
