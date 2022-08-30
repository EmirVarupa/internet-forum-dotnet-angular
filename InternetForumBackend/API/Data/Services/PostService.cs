using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Post;
using API.Data.Dtos.PostComment;
using API.Data.Models;
using API.Data.Repos;
using AutoMapper;

namespace API.Data.Services;

public class PostService : IPostService
{
    private readonly IPostRepo _repo;
    private readonly IMapper _mapper;

    public PostService(IPostRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PostReadAllDto>> GetPostsAsync()
    {
        var result = await _repo.GetPostsAsync();

        return _mapper.Map<IEnumerable<PostReadAllDto>>(result);
    }

    public async Task<IEnumerable<PostReadDto>> GetUsersPostsByUsernameAsync(string username)
    {
        var result = await _repo.GetUsersPostsByUsernameAsync(username);

        return _mapper.Map<IEnumerable<PostReadDto>>(result);
    }

    public async Task AddPostAsync(PostCreateDto postCreateDto)
    {
        var post = _mapper.Map<Post>(postCreateDto);

        await _repo.AddPostAsync(post);
    }

    public async Task<PostReadAllDto> GetPostByIdAsync(int id)
    {
        var postFromRepo = await _repo.GetPostByIdAsync(id);

        return _mapper.Map<PostReadAllDto>(postFromRepo);
    }

    public async Task<IEnumerable<PostReadAllDto>> GetPostByCommunityIdAsync(int communityId, int? userId)
    {
        var postCommentFromRepo = await _repo.GetPostByCommunityIdAsync(communityId, userId);

        return _mapper.Map<IEnumerable<PostReadAllDto>>(postCommentFromRepo);
    }

    public async Task<bool> UpdatePostByIdAsync(int id, PostUpdateDto postUpdateDto)
    {
        var post = _mapper.Map<Post>(postUpdateDto);

        return await _repo.UpdatePostByIdAsync(id, post);
    }

    public async Task<bool> ViewPostAsync(int id)
    {
        return await _repo.ViewPostAsync(id);
    }

    public async Task<bool> ArchivePostByIdAsync(int id)
    {
        return await _repo.ArchivePostByIdAsync(id);
    }
}