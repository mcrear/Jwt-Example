using Jwt.Api.Domain.Model;

namespace Jwt.Api.Domain.Response
{
    public class ProductListResponse : BaseResponse<IEnumerable<Product>>
    {
        public ProductListResponse(IEnumerable<Product> data) : base(data)
        {

        }
        public ProductListResponse(string message) : base(message)
        {

        }
    }
}
