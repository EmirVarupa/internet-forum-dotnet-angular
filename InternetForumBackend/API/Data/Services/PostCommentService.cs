using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.PostComment;
using API.Data.Models;
using API.Data.Repos;
using AutoMapper;

namespace API.Data.Services;

public class PostCommentService : IPostCommentService
{
    private readonly IPostCommentRepo _repo;
    private readonly IMapper _mapper;

    public PostCommentService(IPostCommentRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PostCommentReadAllDto>> GetPostCommentsAsync()
    {
        var result = await _repo.GetPostCommentsAsync();

        return _mapper.Map<IEnumerable<PostCommentReadAllDto>>(result);
    }

    public async Task AddPostCommentAsync(PostCommentCreateDto postCommentCreateDto)
    {
        var post = _mapper.Map<PostComment>(postCommentCreateDto);

        await _repo.AddPostCommentAsync(post);
    }

    public async Task<PostCommentReadAllDto> GetPostCommentByIdAsync(int id)
    {
        var postCommentFromRepo = await _repo.GetPostCommentByIdAsync(id);

        return _mapper.Map<PostCommentReadAllDto>(postCommentFromRepo);
    }

    public async Task<IEnumerable<PostCommentReadDto>> GetPostCommentByPostIdAsync(int postId, int? userId)
    {
        var postCommentFromRepo = await _repo.GetPostCommentByPostIdAsync(postId, userId);

        return _mapper.Map<IEnumerable<PostCommentReadDto>>(postCommentFromRepo);
    }

    public async Task<bool> UpdatePostCommentByIdAsync(int id, PostCommentUpdateDto postCommentUpdateDto)
    {
        var postComment = _mapper.Map<PostComment>(postCommentUpdateDto);

        return await _repo.UpdatePostCommentByIdAsync(id, postComment);
    }


    public async Task<bool> DeletePostCommentByIdAsync(int id)
    {
        return await _repo.DeletePostCommentByIdAsync(id);
    }
}