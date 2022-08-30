using Jwt.Api.Domain.Model;

namespace Jwt.Api.Domain.Repositories
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task<User> GetUserById(int id);
        Task<User> GetUseryByEmailAndPassword(string email, string password);
        Task SaveRefreshToken(int userId, string refreshToken);
        Task<User> GetUserByRefreshToken(string resfreshToken);
        Task RemoveRefreshTokenAsync(User user);
    }
}
