using AutoMapper;
using Jwt.Api.Domain.Model;
using Jwt.Api.Resources;

namespace Jwt.Api.Mapping
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductResource, Product>();
            CreateMap<Product, ProductResource>();
        }
    }
}
