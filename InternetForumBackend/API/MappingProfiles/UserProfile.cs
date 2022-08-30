using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.User;
using API.Data.Models;
using AutoMapper;

namespace API.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateDto, User>();

        CreateMap<User, UserReadAllDto>();

        CreateMap<User, UserReadDto>();

        CreateMap<UserUpdateDto, UserDto>();

        //TODO: Might cause problems, i don't remember how createmap works completely but i think it's fine like this
        CreateMap<UserLoginDto, UserDto>();
    }
}