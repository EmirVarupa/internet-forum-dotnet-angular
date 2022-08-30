using API.Data.Dtos.UserCommunity;
using API.Data.Models;
using API.Data.Repos;
using AutoMapper;

namespace API.Data.Services;

public class UserCommunityService : IUserCommunityService
{
    private readonly IUserCommunityRepo _repo;
    private readonly IMapper _mapper;

    public UserCommunityService(IUserCommunityRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<UserCommunityReadDto> GetUserCommunityByUserIdAsync(int userId, int communityId)
    {
        var userCommunityFromRepo = await _repo.GetUserCommunityByUserIdAsync(userId, communityId);

        return _mapper.Map<UserCommunityReadDto>(userCommunityFromRepo);
    }

    public async Task<IEnumerable<UserCommunityReadDto>> GetUserJoinedCommunitiesByUserIdAsync(int userId)
    {
        var userCommunityFromRepo = await _repo.GetUserJoinedCommunitiesByUserIdAsync(userId);

        return _mapper.Map<IEnumerable<UserCommunityReadDto>>(userCommunityFromRepo);
    }

    public async Task<IEnumerable<UserCommunityReadDto>> GetUserAdminCommunitiesByUserIdAsync(int userId)
    {
        var userCommunityFromRepo = await _repo.GetUserAdminCommunitiesByUserIdAsync(userId);

        return _mapper.Map<IEnumerable<UserCommunityReadDto>>(userCommunityFromRepo);
    }

    public async Task<bool> JoinOrLeaveCommunityByUserIdAsync(UserCommunityCreateDto userCommunityCreateDto)
    {
        var userCommunity = _mapper.Map<UserCommunity>(userCommunityCreateDto);

        return await _repo.JoinOrLeaveCommunityByUserIdAsync(userCommunity);
    }
}