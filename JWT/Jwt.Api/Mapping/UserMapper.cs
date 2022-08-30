using AutoMapper;
using Jwt.Api.Domain.Model;
using Jwt.Api.Resources;

namespace Jwt.Api.Mapping
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserResource, User>();
            CreateMap<User, UserResource>();
        }
    }
}
