using API.Data.Models;

namespace API.Data.Repos;

public interface IUserPostVoteRepo
{
    /*
    Task<IEnumerable<UserPostVote>> GetPostVotesAsync();

    Task<Community> GetCommunityByIdAsync(int id);

    Task AddCommunityAsync(UserPostVote userPostVote);
    */

    Task<IEnumerable<UserPostVote>> GetUserPostVotesByUserIdAsync(int userId);

    Task<IEnumerable<UserPostVote>> GetUserPostVotesByPostIdAsync(int userId);

    Task<IEnumerable<UserPostVote>> GetUserPostVotesByPostAndUserIdAsync(int userId, int postId);

    Task AddUserPostVoteAsync(UserPostVote userPostVote);

    Task<int?> IncrementOrDecrementPostVoteWithUserIdAsync(UserPostVote userPostVote);
}