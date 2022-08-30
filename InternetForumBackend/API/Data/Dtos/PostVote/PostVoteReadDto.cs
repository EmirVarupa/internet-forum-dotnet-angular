using API.Data.Dtos.UserPostVote;

namespace API.Data.Dtos.PostVote;

public class PostVoteReadDto
{
    public int VoteId { get; set; }
    public int VoteCount { get; set; }
    public ICollection<UserPostVoteDto> UserPostVotes { get; set; }
}