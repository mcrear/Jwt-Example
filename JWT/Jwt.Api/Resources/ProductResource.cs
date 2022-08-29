using System.ComponentModel.DataAnnotations;

namespace Jwt.Api.Resources
{
    public class ProductResource
    {
        [Required]
        public int Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public decimal? Price { get; set; }
    }
}
