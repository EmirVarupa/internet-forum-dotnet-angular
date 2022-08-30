namespace API.Data.Models
{
    public class PostCommentVote
    {

        public int VoteId { get; set; }
        public int VoteCount { get; set; }

        public int CommentId { get; set; }

        public PostComment PostComment { get; set; }

        public ICollection<UserPostCommentVote> UserPostCommentVotes { get; set; }

        public PostCommentVote()
        {
            VoteCount = 0;
        }
    }
}
