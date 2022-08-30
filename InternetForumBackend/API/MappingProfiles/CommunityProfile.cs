using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Community;
using API.Data.Models;
using AutoMapper;

namespace API.MappingProfiles;

public class CommunityProfile : Profile
{
    public CommunityProfile()
    {
        CreateMap<CommunityCreateDto, Community>();

        CreateMap<Community, CommunityReadDto>();

        CreateMap<CommunityUpdateDto, Community>();
    }
}