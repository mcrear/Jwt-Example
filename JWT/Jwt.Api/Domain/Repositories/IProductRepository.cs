using Jwt.Api.Domain.Model;

namespace Jwt.Api.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task<Product> GetProductyById(int id);
        Task DeleteProductAsync(int id);
    }
}
