using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Post;
using API.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _service;

    public PostController(IPostService service)
    {
        _service = service;
    }

    [HttpGet("Community")]
    public async Task<IActionResult> GetPostAsync()
    {
        var result = await _service.GetPostsAsync();

        return Ok(result);
    }

    [HttpGet("User/{username}")]
    public async Task<IActionResult> GetUsersPostsByUsernameAsync(string username)
    {
        var result = await _service.GetUsersPostsByUsernameAsync(username);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostByIdAsync(int id)
    {
        var tag = await _service.GetPostByIdAsync(id);
        if (tag == null) return NotFound();

        return Ok(tag);
    }

    [HttpGet("Community/{communityId}")]
    public async Task<IActionResult> GetPostByCommunityIdAsync(int communityId, int userId)
    {
        var result = await _service.GetPostByCommunityIdAsync(communityId, userId);
        if (result == null) return NotFound();

        return Ok(result);
    }

    [HttpGet("Community/{communityId}/{userId}")]
    public async Task<IActionResult> GetPostByCommunityIdAsync(int communityId, int? userId)
    {
        var result = await _service.GetPostByCommunityIdAsync(communityId, userId);
        if (result == null) return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddPostAsync([FromBody] PostCreateDto postCreateDto)
    {
        await _service.AddPostAsync(postCreateDto);

        return StatusCode(201);
    }

    [HttpPut("{postId}")]
    public async Task<IActionResult> UpdatePostAsync(int postId, [FromBody] PostUpdateDto postUpdateDto)
    {
        var result = await _service.UpdatePostByIdAsync(postId, postUpdateDto);

        if (!result) return BadRequest("Update failed!");

        return NoContent();
    }

    [HttpPut("View/{id}")]
    public async Task<IActionResult> ViewPostAsync(int id)
    {
        var result = await _service.ViewPostAsync(id);

        if (!result) return BadRequest("Update failed!");

        return NoContent();
    }

    [HttpPut("Archive/{postId}")]
    public async Task<IActionResult> ArchivePostAsync(int postId)
    {
        var result = await _service.ArchivePostByIdAsync(postId);

        if (!result) return BadRequest("Archive failed!");

        return NoContent();
    }
}