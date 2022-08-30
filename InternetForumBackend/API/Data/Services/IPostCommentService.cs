using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.PostComment;

namespace API.Data.Services;

public interface IPostCommentService
{
    Task<IEnumerable<PostCommentReadAllDto>> GetPostCommentsAsync();

    Task AddPostCommentAsync(PostCommentCreateDto postCommentCreateDto);

    Task<PostCommentReadAllDto> GetPostCommentByIdAsync(int id);

    Task<IEnumerable<PostCommentReadDto>> GetPostCommentByPostIdAsync(int postId, int? userId);

    Task<bool> UpdatePostCommentByIdAsync(int id, PostCommentUpdateDto postCommentUpdateDto);

    Task<bool> DeletePostCommentByIdAsync(int id);
}