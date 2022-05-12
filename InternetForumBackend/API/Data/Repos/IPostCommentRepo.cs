using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;

namespace API.Data.Repos
{
    public interface IPostCommentRepo
    {
        Task<IEnumerable<PostComment>> GetPostCommentsAsync();

        Task AddPostCommentAsync(PostComment postComment);

        Task<PostComment> GetPostCommentByIdAsync(int id);

        Task<IEnumerable<PostComment>> GetPostCommentByPostIdAsync(int id);

        Task<bool> UpdatePostCommentByIdAsync(int id, PostComment postComment);
    }
}
