using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.PostComment;
using API.Data.Models;
using AutoMapper;

namespace API.MappingProfiles;

public class PostCommentProfile : Profile
{
    public PostCommentProfile()
    {
        CreateMap<PostCommentCreateDto, PostComment>();

        CreateMap<PostComment, PostCommentReadAllDto>();

        CreateMap<PostComment, PostCommentReadDto>();

        CreateMap<PostCommentUpdateDto, PostComment>();
    }
}