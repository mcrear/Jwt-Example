using Jwt.Api.Domain.Data;

namespace Jwt.Api.Domain.Repositories
{
    public class BaseRepository
    {
        protected readonly JwtDbContext jwtDbContext;

        public BaseRepository(JwtDbContext jwtDbContext)
        {
            this.jwtDbContext = jwtDbContext;
        }
    }
}
