using API.Data.Dtos.UserPostCommentVote;

namespace API.Data.Dtos.PostCommentVote
{
    public class PostCommentVoteReadDto
    {
        public int VoteId { get; set; }
        public int VoteCount { get; set; }
        public ICollection<UserPostCommentVoteDto> UserPostCommentVotes { get; set; }
    }
}
