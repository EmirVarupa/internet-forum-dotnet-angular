using API.Data.Dtos.UserCommunity;

namespace API.Data.Services;

public interface IUserCommunityService
{

    Task<UserCommunityReadDto> GetUserCommunityByUserIdAsync(int userId, int communityId);
    Task<IEnumerable<UserCommunityReadDto>> GetUserJoinedCommunitiesByUserIdAsync(int userId);

    Task<IEnumerable<UserCommunityReadDto>> GetUserAdminCommunitiesByUserIdAsync(int userId);

    Task<bool> JoinOrLeaveCommunityByUserIdAsync(UserCommunityCreateDto userCommunityCreateDto);
}