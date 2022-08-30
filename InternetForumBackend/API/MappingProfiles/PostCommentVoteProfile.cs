using API.Data.Dtos.PostCommentVote;
using API.Data.Models;
using AutoMapper;

namespace API.MappingProfiles
{
    public class PostCommentVoteProfile : Profile
    {
        public PostCommentVoteProfile()
        {
            CreateMap<PostCommentVote, PostCommentVoteReadDto>();
        }
    }
}
