﻿using AutoMapper;
using Tpback1.Entities;
using Tpback1.Models;

namespace Tpback1.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, CreateAndUpdateUserDto>();
        }

    }
}
