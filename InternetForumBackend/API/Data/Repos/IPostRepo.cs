using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;

namespace API.Data.Repos;

public interface IPostRepo
{
    Task<IEnumerable<Post>> GetPostsAsync();

    Task<IEnumerable<Post>> GetUsersPostsByUsernameAsync(string username);

    Task AddPostAsync(Post post);

    Task<Post> GetPostByIdAsync(int id);

    Task<IEnumerable<Post>> GetPostByCommunityIdAsync(int communityId, int? userId);
    Task<bool> UpdatePostByIdAsync(int id, Post post);

    Task<bool> ViewPostAsync(int id);

    Task<bool> ArchivePostByIdAsync(int id);
}