using Jwt.Api.Domain.Data;

namespace Jwt.Api.Domain.Uow
{
    public class Uow : IUow
    {
        private readonly JwtDbContext jwtDbContext;

        public Uow(JwtDbContext jwtDbContext)
        {
            this.jwtDbContext = jwtDbContext;
        }

        public async Task ComplateAsync()
        {
          await  this.jwtDbContext.SaveChangesAsync();
        }
    }
}
