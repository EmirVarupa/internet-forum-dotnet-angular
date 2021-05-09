using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.PostComment;

namespace API.Data.Services
{
    public interface IPostCommentService
    {
        Task<IEnumerable<PostCommentReadDto>> GetPostCommentsAsync();

        Task AddPostCommentAsync(PostCommentCreateDto postCommentCreateDto);

        Task<PostCommentReadDto> GetPostCommentByIdAsync(int id);

        Task<bool> UpdatePostCommentByIdAsync(int id, PostCommentUpdateDto postCommentUpdateDto);
    }
}
