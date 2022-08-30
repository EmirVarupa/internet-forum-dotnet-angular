namespace API.Data.Dtos.UserPostCommentVote
{
    public class UserPostCommentVoteDto
    {
        public int UserId { get; set; }

        public int PostCommentVoteId { get; set; }

        //upvote/downvote
        public int PostCommentVoteDirection { get; set; }
    }
}
