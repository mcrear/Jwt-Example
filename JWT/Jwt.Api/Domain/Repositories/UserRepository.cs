using Jwt.Api.Domain.Data;
using Jwt.Api.Domain.Model;
using Jwt.Api.Security.Token;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Jwt.Api.Domain.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly TokenOptions _tokenOptions;
        public UserRepository(JwtDbContext jwtDbContext, IOptions<TokenOptions> options) : base(jwtDbContext)
        {
            _tokenOptions = options.Value;
        }

        public async Task Add(User user)
        {
            await jwtDbContext.Users.AddAsync(user);
        }

        public async Task<User> GetUserById(int id)
        {
            return await jwtDbContext.Users.FindAsync(id);
        }

        public async Task<User> GetUserByRefreshToken(string resfreshToken)
        {
            return await jwtDbContext.Users.Where(x => x.RefreshToken == resfreshToken).FirstOrDefaultAsync();
        }

        public async Task<User> GetUseryByEmailAndPassword(string email, string password)
        {
            return await jwtDbContext.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
        }

        public async Task RemoveRefreshTokenAsync(User user)
        {
            var findedUser = await jwtDbContext.Users.FindAsync(user.Id);
            findedUser.RefreshToken = null;
            findedUser.RefreshTokenEndDate = DateTime.MinValue;
        }

        public async Task SaveRefreshToken(int userId, string refreshToken)
        {
            User findedUser = await jwtDbContext.Users.FindAsync(userId);
            findedUser.RefreshToken = refreshToken;
            findedUser.RefreshTokenEndDate = DateTime.Now.AddMinutes(_tokenOptions.RefreshTokenExpration);

        }
    }
}
