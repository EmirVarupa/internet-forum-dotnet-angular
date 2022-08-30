using API.Data.Models;

namespace API.Data.Repos
{
    public interface IUserPostCommentVoteRepo
    {
        Task<IEnumerable<UserPostCommentVote>> GetUserPostCommentVotesByUserIdAsync(int userId);

        Task<IEnumerable<UserPostCommentVote>> GetUserPostCommentVotesByPostCommentIdAsync(int postCommentId);

        Task<IEnumerable<UserPostCommentVote>> GetUserPostCommentVotesByPostCommentAndUserIdAsync(int userId, int postCommentId);

        Task AddUserPostCommentVoteAsync(UserPostCommentVote userPostCommentVote);

        Task<int?> IncrementOrDecrementPostCommentVoteWithUserIdAsync(UserPostCommentVote userPostCommentVote);

    }
}
