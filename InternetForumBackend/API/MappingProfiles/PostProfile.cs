using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Post;
using API.Data.Models;
using AutoMapper;

namespace API.MappingProfiles;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<PostCreateDto, Post>();

        CreateMap<Post, PostReadAllDto>();

        CreateMap<Post, PostReadDto>();

        CreateMap<PostUpdateDto, Post>();
    }
}