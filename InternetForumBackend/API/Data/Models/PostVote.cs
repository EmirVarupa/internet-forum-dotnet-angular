namespace API.Data.Models;

public class PostVote
{
    public int VoteId { get; set; }
    public int VoteCount { get; set; }

    public int PostId { get; set; }

    public Post Post { get; set; }

    public ICollection<UserPostVote> UserPostVotes { get; set; }

    public PostVote()
    {
        VoteCount = 0;
    }
}