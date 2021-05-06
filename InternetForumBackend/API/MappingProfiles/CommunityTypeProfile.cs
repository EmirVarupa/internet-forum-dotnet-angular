using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.CommunityType;
using API.Data.Models;
using AutoMapper;

namespace API.MappingProfiles
{
    public class CommunityTypeProfile : Profile
    {
        public CommunityTypeProfile()
        {
            CreateMap<CommunityTypeCreateDto, CommunityType>();

            CreateMap<CommunityType, CommunityTypeReadDto>();

            CreateMap<CommunityTypeUpdateDto, CommunityType>();
        }
    }
}