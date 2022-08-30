using API.Data.Models;

namespace API.Data.Dtos.UserPostVote;

public class UserPostVoteDto
{
    public int UserId { get; set; }

    public int PostVoteId { get; set; }

    //upvote/downvote
    public int PostVoteDirection { get; set; }
}