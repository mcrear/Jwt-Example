using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jwt.Api.Domain.Model
{
    public partial class User
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
