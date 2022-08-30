using API.Data.Dtos.UserPostCommentVote;

namespace API.Data.Services
{
    public interface IUserPostCommentVoteService
    {
        Task<IEnumerable<UserPostCommentVoteReadDto>> GetUserPostCommentVotesByUserIdAsync(int userId);

        Task<IEnumerable<UserPostCommentVoteReadDto>> GetUserPostCommentVotesByPostCommentIdAsync(int postCommentId);

        Task<IEnumerable<UserPostCommentVoteReadDto>> GetUserPostCommentVotesByPostCommentAndUserIdAsync(int userId, int postCommentId);

        Task AddUserPostCommentVoteAsync(UserPostCommentVoteDto userPostCommentVoteDto);
        Task<int?> IncrementOrDecrementPostCommentVoteWithUserIdAsync(UserPostCommentVoteDto userPostCommentVoteDto);
    }
}
