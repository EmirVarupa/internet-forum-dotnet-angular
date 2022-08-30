using API.Data.Models;

namespace API.Data.Repos;

public interface IUserCommunityRepo
{
    Task<UserCommunity> GetUserCommunityByUserIdAsync(int userId, int communityId);

    Task<IEnumerable<UserCommunity>> GetUserJoinedCommunitiesByUserIdAsync(int userId);

    Task<IEnumerable<UserCommunity>> GetUserAdminCommunitiesByUserIdAsync(int userId);

    //Task AddUserCommunityAsync(UserCommunity userCommunity);

    Task<bool> JoinOrLeaveCommunityByUserIdAsync(UserCommunity userCommunity);
}