using API.Data.Dtos.PostVote;
using API.Data.Models;
using AutoMapper;

namespace API.MappingProfiles;

public class PostVoteProfile : Profile
{
    public PostVoteProfile()
    {
        CreateMap<PostVote, PostVoteReadDto>();
    }
}