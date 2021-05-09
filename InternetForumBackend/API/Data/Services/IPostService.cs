using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Post;

namespace API.Data.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostReadDto>> GetPostsAsync();

        Task AddPostAsync(PostCreateDto postCreateDto);

        Task<PostReadDto> GetPostByIdAsync(int id);

        Task<bool> UpdatePostByIdAsync(int id, PostUpdateDto postUpdateDto);
    }
}
