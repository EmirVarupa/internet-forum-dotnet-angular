using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Roles;
using API.Data.Models;
using AutoMapper;

namespace API.MappingProfiles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<RoleCreateDto, Role>();

        CreateMap<Role, RoleReadDto>();

        CreateMap<RoleUpdateDto, Role>();
    }
}