using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;

namespace API.Data.Repos
{
    public interface IPostRepo
    {
        Task<IEnumerable<Post>> GetPostsAsync();

        Task AddPostAsync(Post post);

        Task<Post> GetPostByIdAsync(int id);

        Task<bool> UpdatePostByIdAsync(int id, Post post);

    }
}
