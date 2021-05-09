using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repos
{
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
                .ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public async Task AddPostAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            var postFromDb = await _context.Posts
                .Include(p => p.Community)
                .Include(p => p.User)
                .SingleOrDefaultAsync(p => p.PostId == id);

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

            if (postFromDb == null)
            {
                return false;
            }

            postFromDb.CommunityId = post.CommunityId;
            postFromDb.UserId = post.UserId;
            postFromDb.PostTitle = post.PostTitle;
            postFromDb.PostContent = post.PostContent;
            postFromDb.ImageUrl = post.ImageUrl;
            postFromDb.Upvotes = post.Upvotes;
            postFromDb.Link = post.Link;
            postFromDb.IsSpoiler = post.IsSpoiler;

            return await _context.SaveChangesAsync() >= 0;
        }

    }
}

