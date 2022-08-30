using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repos;
public class UserPostCommentVoteRepo : IUserPostCommentVoteRepo
{
    private readonly ForumContext _context;

    public UserPostCommentVoteRepo(ForumContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserPostCommentVote>> GetUserPostCommentVotesByUserIdAsync(int userId)
    {
        var userPostCommentVoteFromDb = await _context.UserPostCommentVotes
            .Include(upv => upv.User)
            .Include(upv => upv.PostCommentVote)
            .Where(upv => upv.UserId == userId)
            .ToListAsync();

        return userPostCommentVoteFromDb;
    }

    public async Task<IEnumerable<UserPostCommentVote>> GetUserPostCommentVotesByPostCommentIdAsync(int postCommentId)
    {
        var userPostCommentVoteFromDb = await _context.UserPostCommentVotes
            .Include(upcv => upcv.User)
            .Include(upcv => upcv.PostCommentVote)
            .Where(upv => upv.PostCommentVoteId == postCommentId)
            .ToListAsync();

        return userPostCommentVoteFromDb;
    }

    public async Task<IEnumerable<UserPostCommentVote>> GetUserPostCommentVotesByPostCommentAndUserIdAsync(int userId, int postCommentId)
    {
        var userPostCommentVoteFromDb = await _context.UserPostCommentVotes
            .Include(upv => upv.User)
            .Include(upv => upv.PostCommentVote)
            .Where(upv => upv.PostCommentVoteId == postCommentId && upv.UserId == userId)
            .ToListAsync();

        return userPostCommentVoteFromDb;
    }

    public async Task AddUserPostCommentVoteAsync(UserPostCommentVote userPostCommentVote)
    {

        var postCommentVotes = new UserPostCommentVote
        {
            PostCommentVoteId = userPostCommentVote.PostCommentVoteId,
            UserId = userPostCommentVote.UserId,
            PostCommentVoteDirection = userPostCommentVote.PostCommentVoteDirection
        };

        _context.UserPostCommentVotes.Add(postCommentVotes);
        await _context.SaveChangesAsync();

    }

    public async Task<int?> IncrementOrDecrementPostCommentVoteWithUserIdAsync(UserPostCommentVote userPostCommentVote)
    {
        //Check if User Exists
        var userFromDb = await _context.Users
            .Where(u => u.UserId == userPostCommentVote.UserId)
            .Include(u => u.UserPostVotes)
            .FirstOrDefaultAsync();
        if (userFromDb == null)
            return null;

        //Check if PostCommentVote Exists (looks for PostCommentId instead of VoteId)
        var postCommentVoteFromDb = await _context.PostCommentVotes
            .Where(upv => upv.VoteId == userPostCommentVote.PostCommentVoteId)
            .FirstOrDefaultAsync();
        if (postCommentVoteFromDb == null)
            return null;

        //Check if userPostCommentVotes Exists, if userPostCommentVotes doesn't exist, create new userPostCommentVote
        var userPostCommentVoteFromDb = await _context.UserPostCommentVotes.FindAsync(userPostCommentVote.UserId, userPostCommentVote.PostCommentVoteId);
        if (userPostCommentVoteFromDb == null)
        {
            _context.ChangeTracker.Clear();
            postCommentVoteFromDb = await _context.PostCommentVotes
                .Where(upv => upv.VoteId == userPostCommentVote.PostCommentVoteId)
                .FirstOrDefaultAsync();
            if (postCommentVoteFromDb == null)
                return null;
            await _context.UserPostCommentVotes.AddAsync(userPostCommentVote);
            if (userPostCommentVote.PostCommentVoteDirection == 1)
                postCommentVoteFromDb.VoteCount++;
            else if (userPostCommentVote.PostCommentVoteDirection == -1) postCommentVoteFromDb.VoteCount--;

        }
        else
        {
            if (userPostCommentVoteFromDb.PostCommentVoteDirection == 0)
            {
                if (userPostCommentVote.PostCommentVoteDirection == 1)
                {
                    userPostCommentVoteFromDb.PostCommentVoteDirection = 1;
                    postCommentVoteFromDb.VoteCount++;
                }
                else if (userPostCommentVote.PostCommentVoteDirection == -1)
                {
                    userPostCommentVoteFromDb.PostCommentVoteDirection = -1;
                    postCommentVoteFromDb.VoteCount--;
                }
            }
            else if (userPostCommentVoteFromDb.PostCommentVoteDirection == 1)
            {
                if (userPostCommentVote.PostCommentVoteDirection == 1)
                {
                    userPostCommentVoteFromDb.PostCommentVoteDirection = 0;
                    postCommentVoteFromDb.VoteCount--;
                }
                else if (userPostCommentVote.PostCommentVoteDirection == -1)
                {
                    userPostCommentVoteFromDb.PostCommentVoteDirection = -1;
                    postCommentVoteFromDb.VoteCount -= 2;
                }
            }
            else if (userPostCommentVoteFromDb.PostCommentVoteDirection == -1)
            {
                if (userPostCommentVote.PostCommentVoteDirection == 1)
                {
                    userPostCommentVoteFromDb.PostCommentVoteDirection = 1;
                    postCommentVoteFromDb.VoteCount += 2;
                }
                else if (userPostCommentVote.PostCommentVoteDirection == -1)
                {
                    userPostCommentVoteFromDb.PostCommentVoteDirection = 0;
                    postCommentVoteFromDb.VoteCount++;
                }
            }
            else
            {
                return null;
            }
        }
        await _context.SaveChangesAsync();

        return postCommentVoteFromDb.VoteCount;
    }
}

