using Jwt.Api.Domain.Data;
using Jwt.Api.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Jwt.Api.Domain.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(JwtDbContext jwtDbContext) : base(jwtDbContext)
        {
        }

        public async Task AddProduct(Product product)
        {
            await jwtDbContext.Products.AddAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            var item = await GetProductyById(id);

            jwtDbContext.Products.Remove(item);
        }

        public async Task<Product> GetProductyById(int id)
        {
            return await jwtDbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await jwtDbContext.Products.ToListAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            jwtDbContext.Products.Update(product);
        }
    }
}
