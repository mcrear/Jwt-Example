using Jwt.Api.Domain.Model;
using Jwt.Api.Domain.Response;

namespace Jwt.Api.Domain.Services
{
    public interface IUserService
    {
        Task<UserResponse> Add(User user);
        Task<UserResponse> GetUserById(int id);
        Task<UserResponse> GetUseryByEmailAndPassword(string email, string password);
        Task SaveRefreshToken(int userId, string refreshToken);
        Task<UserResponse> GetUserByRefreshToken(string resfreshToken);
        Task RemoveRefreshTokenAsync(User user);
    }
}
