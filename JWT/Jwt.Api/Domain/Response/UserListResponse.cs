using Jwt.Api.Domain.Model;

namespace Jwt.Api.Domain.Response
{
    public class UserListResponse : BaseResponse<IEnumerable<User>>
    {
        public UserListResponse(IEnumerable<User> user) : base(user)
        {

        }
        public UserListResponse(string message) : base(message)
        {

        }
    }
}
