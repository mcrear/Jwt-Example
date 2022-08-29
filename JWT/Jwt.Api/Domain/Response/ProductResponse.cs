
using Jwt.Api.Domain.Model;

namespace Jwt.Api.Domain.Response
{
    public class ProductResponse : BaseResponse<Product>
    {
        public ProductResponse(Product product) : base(true, "", product)
        {

        }
        public ProductResponse(string message) : base(false, message, null)
        {

        }
    }
}
