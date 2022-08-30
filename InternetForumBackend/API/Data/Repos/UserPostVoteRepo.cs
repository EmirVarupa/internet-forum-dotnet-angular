using System.Net;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repos;

public class UserPostVoteRepo : IUserPostVoteRepo
{
    private readonly ForumContext _context;

    public UserPostVoteRepo(ForumContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserPostVote>> GetUserPostVotesByUserIdAsync(int userId)
    {
        var userPostVoteFromDb = await _context.UserPostVotes
            .Include(upv => upv.User)
            .Include(upv => upv.PostVote)
            .Where(upv => upv.UserId == userId)
            .ToListAsync();

        return userPostVoteFromDb;
    }

    public async Task<IEnumerable<UserPostVote>> GetUserPostVotesByPostIdAsync(int postId)
    {
        var userPostVoteFromDb = await _context.UserPostVotes
            .Include(upv => upv.User)
            .Include(upv => upv.PostVote)
            .Where(upv => upv.PostVoteId == postId)
            .ToListAsync();

        return userPostVoteFromDb;
    }

    public async Task<IEnumerable<UserPostVote>> GetUserPostVotesByPostAndUserIdAsync(int userId, int postId)
    {
        var userPostVoteFromDb = await _context.UserPostVotes
            .Include(upv => upv.User)
            .Include(upv => upv.PostVote)
            .Where(upv => upv.PostVoteId == postId && upv.UserId == userId)
            .ToListAsync();

        return userPostVoteFromDb;
    }

    public async Task AddUserPostVoteAsync(UserPostVote userPostVote)
    {
        //var character = await _context.UserPostVotes
        //    .Where(c => c.UserId == userPostVote.UserId)
        //    .Include(c => c.PostVote)
        //    .FirstOrDefaultAsync();

        //var user = _context.Users.First();
        //var postvote = _context.PostVotes.First();

        var postVotes = new UserPostVote
        {
            PostVoteId = userPostVote.PostVoteId,
            UserId = userPostVote.UserId,
            PostVoteDirection = userPostVote.PostVoteDirection
        };

        _context.UserPostVotes.Add(postVotes);
        await _context.SaveChangesAsync();

        //await _context.UserPostVotes.AddAsync(userPostVote);
        //await _context.SaveChangesAsync();

        //if (character == null)
        //    return void;

        //var skill = await _context.UserPostVotes.FindAsync(userPostVote.PostVoteId);
        ////if (skill == null)
        ////    return NotFound();

        //character..Add(skill);
        //await _context.SaveChangesAsync();

        //return character;
    }

    public async Task<int?> IncrementOrDecrementPostVoteWithUserIdAsync(UserPostVote userPostVote)
    {
        //Check if User Exists
        var userFromDb = await _context.Users
            .Where(u => u.UserId == userPostVote.UserId)
            .Include(u => u.UserPostVotes)
            .FirstOrDefaultAsync();
        if (userFromDb == null)
            return null;

        //Check if PostVote Exists (looks for PostId instead of VoteId)
        var postVoteFromDb = await _context.PostVotes
            .Where(upv => upv.VoteId == userPostVote.PostVoteId)
            .FirstOrDefaultAsync();
        if (postVoteFromDb == null)
            return null;

        //Check if userPostVotes Exists, if userPostVotes doesn't exist, create new userPostVote
        var userPostVoteFromDb = await _context.UserPostVotes.FindAsync(userPostVote.UserId, userPostVote.PostVoteId);
        if (userPostVoteFromDb == null)
        {
            _context.ChangeTracker.Clear();
            postVoteFromDb = await _context.PostVotes
                .Where(upv => upv.VoteId == userPostVote.PostVoteId)
                .FirstOrDefaultAsync();
            if (postVoteFromDb == null)
                return null;
            await _context.UserPostVotes.AddAsync(userPostVote);
            if (userPostVote.PostVoteDirection == 1)
                postVoteFromDb.VoteCount++;
            else if (userPostVote.PostVoteDirection == -1) postVoteFromDb.VoteCount--;
        }
        else
        {
            if (userPostVoteFromDb.PostVoteDirection == 0)
            {
                if (userPostVote.PostVoteDirection == 1)
                {
                    userPostVoteFromDb.PostVoteDirection = 1;
                    postVoteFromDb.VoteCount++;
                }
                else if (userPostVote.PostVoteDirection == -1)
                {
                    userPostVoteFromDb.PostVoteDirection = -1;
                    postVoteFromDb.VoteCount--;
                }
            }
            else if (userPostVoteFromDb.PostVoteDirection == 1)
            {
                if (userPostVote.PostVoteDirection == 1)
                {
                    userPostVoteFromDb.PostVoteDirection = 0;
                    postVoteFromDb.VoteCount--;
                }
                else if (userPostVote.PostVoteDirection == -1)
                {
                    userPostVoteFromDb.PostVoteDirection = -1;
                    postVoteFromDb.VoteCount -= 2;
                }
            }
            else if (userPostVoteFromDb.PostVoteDirection == -1)
            {
                if (userPostVote.PostVoteDirection == 1)
                {
                    userPostVoteFromDb.PostVoteDirection = 1;
                    postVoteFromDb.VoteCount += 2;
                }
                else if (userPostVote.PostVoteDirection == -1)
                {
                    userPostVoteFromDb.PostVoteDirection = 0;
                    postVoteFromDb.VoteCount++;
                }
            }
            else
            {
                return null;
            }
        }
        await _context.SaveChangesAsync() ;

        return postVoteFromDb.VoteCount;
    }
}