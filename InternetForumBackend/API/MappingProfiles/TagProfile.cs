using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Tag;
using API.Data.Models;
using AutoMapper;

namespace API.MappingProfiles;

public class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<TagCreateDto, Tag>();

        CreateMap<Tag, TagReadDto>();

        CreateMap<TagUpdateDto, Tag>();
    }
}