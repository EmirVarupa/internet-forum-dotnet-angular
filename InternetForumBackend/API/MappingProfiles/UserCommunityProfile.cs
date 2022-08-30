using API.Data.Dtos.UserCommunity;
using API.Data.Dtos.UserPostVote;
using API.Data.Models;
using AutoMapper;

namespace API.MappingProfiles;

public class UserCommunityProfile : Profile
{
    public UserCommunityProfile()
    {
        CreateMap<UserCommunityCreateDto, UserCommunity>();

        CreateMap<UserCommunity, UserCommunityReadDto>();
    }
}