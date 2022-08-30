using API.Data.Dtos.UserPostVote;
using API.Data.Models;
using AutoMapper;

namespace API.MappingProfiles;

public class UserPostVoteProfile : Profile
{
    public UserPostVoteProfile()
    {
        CreateMap<UserPostVoteDto, UserPostVote>();

        CreateMap<UserPostVote, UserPostVoteReadDto>();

        CreateMap<UserPostVote, UserPostVoteDto>();
    }
}