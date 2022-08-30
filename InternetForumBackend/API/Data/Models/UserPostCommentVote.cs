namespace API.Data.Models
{
    public class UserPostCommentVote
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int PostCommentVoteId { get; set; }

        public PostCommentVote PostCommentVote { get; set; }

        //upvote/downvote
        public int PostCommentVoteDirection { get; set; }
    }
}
