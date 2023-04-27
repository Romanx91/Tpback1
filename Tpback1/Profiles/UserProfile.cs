using AutoMapper;
using Tpback1.Entities;
using Tpback1.Models.Dtos;

namespace Tpback1.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UpdateUser>();
            CreateMap<User, CreateAndUpdateUserDto>();
            CreateMap<User, GetUserByIdResponse>();
        }

    }
}
