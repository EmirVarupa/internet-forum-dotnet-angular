using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repos;

public class UserCommunityRepo : IUserCommunityRepo
{
    private readonly ForumContext _context;

    public UserCommunityRepo(ForumContext context)
    {
        _context = context;
    }

    public async Task<UserCommunity> GetUserCommunityByUserIdAsync(int userId, int communityId)
    {
        var userPostVoteFromDb = await _context.UserCommunities
            .Include(upv => upv.User)
            .Include(upv => upv.Community)
            .FirstOrDefaultAsync(upv => upv.UserId == userId && upv.CommunityId == communityId);

        return userPostVoteFromDb;
    }

    public async Task<IEnumerable<UserCommunity>> GetUserJoinedCommunitiesByUserIdAsync(int userId)
    {
        var userPostVoteFromDb = await _context.UserCommunities
            .Include(upv => upv.User)
            .Include(upv => upv.Community)
            .Where(upv => upv.UserId == userId && upv.IsJoined && upv.Community.IsArchived == false)
            .ToListAsync();

        return userPostVoteFromDb;
    }

    public async Task<IEnumerable<UserCommunity>> GetUserAdminCommunitiesByUserIdAsync(int userId)
    {
        var userPostVoteFromDb = await _context.UserCommunities
            .Include(upv => upv.User)
            .Include(upv => upv.Community)
            .Where(upv => upv.Role == "Admin" && upv.UserId == userId && upv.Community.IsArchived == false)
            .ToListAsync();

        return userPostVoteFromDb;
    }

    /*
    public async Task AddUserCommunityAsync(UserCommunity userCommunity)
    {


        UserCommunity userCommunities = new UserCommunity
        {
            CommunityId = userCommunity.CommunityId,
            UserId = userCommunity.UserId,
            IsJoined = true,
            Role = "User"
        };

        _context.UserCommunities.Add(userCommunities);
        await _context.SaveChangesAsync();

    }
    */

    public async Task<bool> JoinOrLeaveCommunityByUserIdAsync(UserCommunity userCommunity)
    {
        //Check if User Exists
        var userFromDb = await _context.Users
            .Where(u => u.UserId == userCommunity.UserId)
            .Include(u => u.UserCommunities)
            .FirstOrDefaultAsync();
        if (userFromDb == null)
            return false;

        //Check if Community Exists
        var communityFromDb = await _context.Communities.FindAsync(userCommunity.CommunityId);
        if (communityFromDb == null)
            return false;

        //Check if User joined community, if user didn't join community, create record and join community with isJoined = true
        var userCommunityFromDb =
            await _context.UserCommunities.FindAsync(userCommunity.CommunityId, userCommunity.UserId);
        if (userCommunityFromDb == null)
        {
            _context.ChangeTracker.Clear();

            var userCommunities = new UserCommunity
            {
                CommunityId = userCommunity.CommunityId,
                UserId = userCommunity.UserId,
                IsJoined = userCommunity.IsJoined,
                Role = "User"
            };

            await _context.UserCommunities.AddAsync(userCommunities);
        }
        else
        {
            userCommunityFromDb.IsJoined = userCommunity.IsJoined;
            //if (userCommunityFromDb.IsJoined)
            //    userCommunityFromDb.IsJoined = false;
            //else
            //    userCommunityFromDb.IsJoined = true;
        }

        return await _context.SaveChangesAsync() >= 0;
    }
}