using Jwt.Api.Domain.Model;
using Jwt.Api.Domain.Repositories;
using Jwt.Api.Domain.Response;
using Jwt.Api.Domain.Services;
using Jwt.Api.Domain.Uow;

namespace Jwt.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUow _uow;

        public ProductService(IProductRepository productRepository, IUow uow)
        {
            _productRepository = productRepository;
            _uow = uow;
        }

        public async Task<ProductResponse> AddProduct(Product product)
        {
            try
            {
                await _productRepository.AddProduct(product);
                await _uow.ComplateAsync();

                return new ProductResponse(product);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"Ürün eklenirken hata meydana geldi: {ex.Message}");
            }
        }

        public async Task<ProductResponse> DeleteAsync(int id)
        {
            try
            {
                var item = await _productRepository.GetProductyById(id);
                await _productRepository.DeleteProductAsync(id);
                await _uow.ComplateAsync();
                return new ProductResponse(item);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"Ürün silinirken hata meydana geldi: {ex.Message}");
            }
        }

        public async Task<ProductResponse> GetAsync(int id)
        {
            try
            {
                var prod = await _productRepository.GetProductyById(id);
                return new ProductResponse(prod);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"Ürün gösterilirken hata meydana geldi: {ex.Message}");
            }
        }

        public async Task<ProductListResponse> ListAsync()
        {
            try
            {
                var prods = await _productRepository.ListAsync();
                return new ProductListResponse(prods);
            }
            catch (Exception ex)
            {
                return new ProductListResponse($"Ürünler listelenirken hata meydana geldi: {ex.Message}");
                throw;
            }
        }

        public async Task<ProductResponse> UpdateAsync(Product product, int id)
        {
            try
            {
                var item = await _productRepository.GetProductyById(id);
                item.Category = product.Category;
                item.Price = product.Price;
                item.Name = product.Name;

                await _productRepository.UpdateProduct(item);
                await _uow.ComplateAsync();

                return new ProductResponse(item);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"Ürün güncellenirken hata meydana geldi: {ex.Message}");
            }
        }
    }
}
