using API.Data.Dtos.UserPostCommentVote;
using API.Data.Models;
using AutoMapper;

namespace API.MappingProfiles;
public class UserPostCommentVoteProfile : Profile
    {
        public UserPostCommentVoteProfile()
        {
            CreateMap<UserPostCommentVoteDto, UserPostCommentVote>();

            CreateMap<UserPostCommentVote, UserPostCommentVoteReadDto>();

            CreateMap<UserPostCommentVote, UserPostCommentVoteDto>();
        }
    }