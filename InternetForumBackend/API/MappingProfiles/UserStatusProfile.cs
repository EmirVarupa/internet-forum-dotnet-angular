using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.UserStatus;
using API.Data.Models;
using AutoMapper;

namespace API.MappingProfiles
{
    public class UserStatusProfile : Profile
    {
        public UserStatusProfile()
        {
            CreateMap<UserStatusCreateDto, UserStatus>();

            CreateMap<UserStatus, UserStatusReadDto>();

            CreateMap<UserStatusUpdateDto, UserStatus>();
        }
        
    }
}
