using System;
using System.Collections.Generic;

namespace Jwt.Api.Domain.Model
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public decimal? Price { get; set; }
    }
}
