using API.Data.Dtos.UserPostVote;

namespace API.Data.Services;

public interface IUserPostVoteService
{
    Task<IEnumerable<UserPostVoteReadDto>> GetUserPostVotesByUserIdAsync(int userId);

    Task<IEnumerable<UserPostVoteReadDto>> GetUserPostVotesByPostIdAsync(int userId);

    Task<IEnumerable<UserPostVoteReadDto>> GetUserPostVotesByPostAndUserIdAsync(int userId, int postId);

    Task AddUserPostVoteAsync(UserPostVoteDto userPostVoteDto);
    Task<int?> IncrementOrDecrementPostVoteWithUserIdAsync(UserPostVoteDto userPostVoteDto);
}