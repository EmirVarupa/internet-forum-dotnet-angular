using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repos;

public class PostCommentRepo : IPostCommentRepo
{
    private readonly ForumContext _context;

    public PostCommentRepo(ForumContext context)
    {
        _context = context;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>List of posts</returns>
    public async Task<IEnumerable<PostComment>> GetPostCommentsAsync()
    {
        return await _context.PostComments
            .Include(p => p.Post)
            .Include(p => p.User)
            .Include(p => p.PostCommentVote)
            .ToListAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    public async Task AddPostCommentAsync(PostComment postComment)
    {
        await _context.PostComments.AddAsync(postComment);
        await _context.SaveChangesAsync();

        await _context.PostCommentVotes.AddAsync(new PostCommentVote
        {
            VoteCount = 0,
            CommentId = postComment.CommentId
        });

        await _context.SaveChangesAsync();
    }

    public async Task<PostComment> GetPostCommentByIdAsync(int id)
    {
        var postCommentFromDb = await _context.PostComments
            .Include(p => p.Post)
            .Include(p => p.User)
            .Include(p => p.PostCommentVote)
            .FirstOrDefaultAsync(p => p.CommentId == id);

        return postCommentFromDb;
    }

    /// <summary>
    /// Gets Comments for a specific post by PostId
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IEnumerable<PostComment>> GetPostCommentByPostIdAsync(int postId, int? userId)
    {
        List<PostComment> postCommentFromDb;
        if (userId != null)
            postCommentFromDb = await _context.PostComments
                .Include(p => p.Post)
                .Include(p => p.User)
                .Include(p => p.PostCommentVote.UserPostCommentVotes.Where(upv => upv.UserId == userId))
                .Where(p => p.PostId == postId)
                .ToListAsync();
        else
            postCommentFromDb = await _context.PostComments
                .Include(p => p.Post)
                .Include(p => p.User)
                .Include(p => p.PostCommentVote)
                .Where(p => p.PostId == postId)
                .ToListAsync();

        return postCommentFromDb;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="postComment"></param>
    /// <returns></returns>
    public async Task<bool> UpdatePostCommentByIdAsync(int id, PostComment postComment)
    {
        var postCommentFromDb = await GetPostCommentByIdAsync(id);

        if (postCommentFromDb == null) return false;

        postCommentFromDb.PostId = postComment.PostId;
        postCommentFromDb.UserId = postComment.UserId;
        postCommentFromDb.CommentContent = postComment.CommentContent;

        return await _context.SaveChangesAsync() >= 0;
    }

    public async Task<bool> DeletePostCommentByIdAsync(int id)
    {
        var postCommentFromDb = _context.PostComments.FirstOrDefault(s => s.CommentId == id);
        var postCommentVoteFromDb = _context.PostCommentVotes.FirstOrDefault(s => s.CommentId == id);
        if (postCommentFromDb == null && postCommentVoteFromDb != null)
        {
            _context.PostCommentVotes.Remove(postCommentVoteFromDb);
        } else if (postCommentFromDb != null && postCommentVoteFromDb == null)
        {
            _context.PostComments.Remove(postCommentFromDb);
        } else if (postCommentFromDb != null && postCommentVoteFromDb != null)
        {
            _context.PostCommentVotes.Remove(postCommentVoteFromDb);
            _context.PostComments.Remove(postCommentFromDb);
        } else if (postCommentFromDb == null && postCommentVoteFromDb == null)
        {
            return false;
        }
        return await _context.SaveChangesAsync() >= 0;
    }
}