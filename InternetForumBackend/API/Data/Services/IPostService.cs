using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Post;

namespace API.Data.Services;

public interface IPostService
{
    Task<IEnumerable<PostReadAllDto>> GetPostsAsync();

    Task<IEnumerable<PostReadDto>> GetUsersPostsByUsernameAsync(string username);

    Task AddPostAsync(PostCreateDto postCreateDto);

    Task<PostReadAllDto> GetPostByIdAsync(int id);

    Task<IEnumerable<PostReadAllDto>> GetPostByCommunityIdAsync(int communityId, int? userId);

    Task<bool> UpdatePostByIdAsync(int id, PostUpdateDto postUpdateDto);
    Task<bool> ViewPostAsync(int id);

    Task<bool> ArchivePostByIdAsync(int id);
}