using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repos;

public class PostRepo : IPostRepo
{
    private readonly ForumContext _context;

    public PostRepo(ForumContext context)
    {
        _context = context;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>List of posts</returns>
    public async Task<IEnumerable<Post>> GetPostsAsync()
    {
        return await _context.Posts
            .Include(p => p.Community)
            .Include(p => p.User)
            .Include(p => p.PostVote)
            .Where(p => p.IsArchived == false)
            .OrderByDescending(p => p.ViewsCount)
            .ToListAsync();
    }

    public async Task<IEnumerable<Post>> GetUsersPostsByUsernameAsync(string username)
    {
        return await _context.Posts
            .Include(p => p.Community)
            .Include(p => p.User)
            .Include(p => p.PostVote)
            .Where(p => p.User.Username == username)
            .ToListAsync();
    }

    /// <summary>
    /// Adds a Post along with PostViews
    /// </summary>
    /// <param name="user"></param>
    public async Task AddPostAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();

        //NOTE: This should be in PostVote Controller but it's much easier to do it on post creation
        await _context.PostVotes.AddAsync(new PostVote
        {
            VoteCount = 0,
            PostId = post.PostId
        });
        await _context.SaveChangesAsync();
    }

    public async Task<Post> GetPostByIdAsync(int id)
    {
        var postFromDb = await _context.Posts
            .Include(p => p.Community)
            .Include(p => p.User)
            .Include(p => p.PostVote)
            .SingleOrDefaultAsync(p => p.PostId == id);

        return postFromDb;
    }

    /// <summary>
    /// Gets Comments for a specific post by PostId
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Post>> GetPostByCommunityIdAsync(int communityId, int? userId)
    {
        List<Post> postFromDb;
        if (userId != null)
            postFromDb = await _context.Posts
                .Include(p => p.Community)
                //TODO: Mozda User bude pravio problem
                .Include(p => p.User)
                .Include(p => p.PostVote.UserPostVotes.Where(upv => upv.UserId == userId))
                .Where(p => p.CommunityId == communityId && p.IsArchived == false)
                .ToListAsync();
        else
            postFromDb = await _context.Posts
                .Include(p => p.Community)
                //TODO: Mozda User bude pravio problem
                .Include(p => p.User)
                .Include(p => p.PostVote)
                .Where(p => p.CommunityId == communityId && p.IsArchived == false)
                .ToListAsync();

        return postFromDb;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="post"></param>
    /// <returns></returns>
    public async Task<bool> UpdatePostByIdAsync(int id, Post post)
    {
        var postFromDb = await GetPostByIdAsync(id);

        if (postFromDb == null) return false;

        //postFromDb.CommunityId = post.CommunityId;
        //postFromDb.UserId = post.UserId;
        postFromDb.PostTitle = post.PostTitle;
        postFromDb.PostContent = post.PostContent;
        postFromDb.ImageUrl = post.ImageUrl;
        //TODO: removed Upvotes added PostVote Model, will need to change this as well
        //postFromDb.Upvotes = post.Upvotes;
        postFromDb.Link = post.Link;
        postFromDb.IsSpoiler = post.IsSpoiler;

        return await _context.SaveChangesAsync() >= 0;
    }

    public async Task<bool> ViewPostAsync(int id)
    {
        var postFromDb = await GetPostByIdAsync(id);

        if (postFromDb == null) return false;

        postFromDb.ViewsCount++;

        return await _context.SaveChangesAsync() >= 0;
    }


    public async Task<bool> ArchivePostByIdAsync(int id)
    {
        //V2
        //var postFromDb = _context.Posts.FirstOrDefault(p => p.PostId == id);
        //var postVoteFromDb = _context.PostVotes.FirstOrDefault(p => p.PostId == id);
        //if (postFromDb == null || postVoteFromDb == null) return false;

        //_context.PostVotes.Remove(postVoteFromDb);
        //_context.Posts.Remove(postFromDb);


        //V1
        //var postCommentFromDb = _context.PostComments.FirstOrDefault(pc => pc.CommentId == id);
        //var postCommentVoteFromDb = _context.PostCommentVotes.FirstOrDefault(pcv => pcv.CommentId == id);
        //if (postCommentFromDb == null && postCommentVoteFromDb != null)
        //{
        //    _context.PostCommentVotes.Remove(postCommentVoteFromDb);
        //}
        //else if (postCommentFromDb != null && postCommentVoteFromDb == null)
        //{
        //    _context.PostComments.Remove(postCommentFromDb);
        //}
        //else if (postCommentFromDb != null && postCommentVoteFromDb != null)
        //{
        //    _context.PostCommentVotes.Remove(postCommentVoteFromDb);
        //    _context.PostComments.Remove(postCommentFromDb);
        //}
        //else if (postCommentFromDb == null && postCommentVoteFromDb == null)
        //{
        //    return false;
        //}

        //V3
        var postFromDb = _context.Posts.FirstOrDefault(p => p.PostId == id);
        if (postFromDb == null) return false;
        postFromDb.IsArchived = true;

        return await _context.SaveChangesAsync() >= 0;
    }

}