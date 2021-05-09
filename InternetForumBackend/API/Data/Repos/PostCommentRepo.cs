using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repos
{
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
        }

        public async Task<PostComment> GetPostCommentByIdAsync(int id)
        {
            var postCommentFromDb = await _context.PostComments
                .Include(p => p.Post)
                .Include(p => p.User)
                .SingleOrDefaultAsync(p => p.CommentId == id);

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

            if (postCommentFromDb == null)
            {
                return false;
            }

            postCommentFromDb.PostId = postComment.PostId;
            postCommentFromDb.UserId = postComment.UserId;
            postCommentFromDb.CommentContent = postComment.CommentContent;

            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
