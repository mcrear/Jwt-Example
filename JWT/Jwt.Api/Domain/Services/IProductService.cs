using Jwt.Api.Domain.Model;
using Jwt.Api.Domain.Response;

namespace Jwt.Api.Domain.Services
{
    public interface IProductService
    {
        Task<ProductListResponse> ListAsync();
        Task<ProductResponse> GetAsync(int id);
        Task<ProductResponse> UpdateAsync(Product product, int id);
        Task<ProductResponse> DeleteAsync(int id);
        Task<ProductResponse> AddProduct(Product product);
    }
}
