using System.ComponentModel.DataAnnotations;

namespace Jwt.Api.Resources
{
    public class LoginResource
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
