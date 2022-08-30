using Jwt.Api.Domain.Model;

namespace Jwt.Api.Domain.Response
{
    public class UserResponse : BaseResponse<User>
    {
        public UserResponse(User user) : base(user)
        {

        }
        public UserResponse(string message) : base(message)
        {

        }
    }
}
