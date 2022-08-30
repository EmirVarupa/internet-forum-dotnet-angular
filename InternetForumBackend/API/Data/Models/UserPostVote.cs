namespace API.Data.Models;

public class UserPostVote
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int PostVoteId { get; set; }

    public PostVote PostVote { get; set; }

    //upvote/downvote
    public int PostVoteDirection { get; set; }
}