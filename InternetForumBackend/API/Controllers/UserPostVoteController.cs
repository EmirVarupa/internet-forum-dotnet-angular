using API.Data.Dtos.UserPostVote;
using API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserPostVoteController : ControllerBase
{
    private readonly IUserPostVoteService _service;

    public UserPostVoteController(IUserPostVoteService service)
    {
        _service = service;
    }

    //TODO: remove httput ID and id from methods
    [HttpPut]
    public async Task<IActionResult> IncrementPostVoteWithUserIdAsync([FromBody] UserPostVoteDto userPostVoteDto)
    {
        var result = await _service.IncrementOrDecrementPostVoteWithUserIdAsync(userPostVoteDto);

        if (result == null) return BadRequest("Update failed!");

        return Ok(result);
    }

    [HttpGet("User/{userId}")]
    public async Task<IActionResult> GetUserPostVotesByUserIdAsync(int userId)
    {
        var result = await _service.GetUserPostVotesByUserIdAsync(userId);
        if (!result.Any()) return NotFound();

        return Ok(result);
    }

    [HttpGet("User/{postId}")]
    public async Task<IActionResult> GetUserPostVotesByPostIdAsync(int postId)
    {
        var result = await _service.GetUserPostVotesByUserIdAsync(postId);
        if (!result.Any()) return NotFound();

        return Ok(result);
    }

    [HttpGet("User")]
    public async Task<IActionResult> GetUserPostVotesByPostAndUserIdAsync(int userId, int postId)
    {
        var result = await _service.GetUserPostVotesByPostAndUserIdAsync(userId, postId);
        if (!result.Any()) return NotFound();

        return Ok(result);
    }

    [HttpPost("AddUserPostVoteAsync")]
    public async Task<ActionResult<UserPostVoteDto>> AddUserPostVoteAsync(UserPostVoteDto request)
    {
        await _service.AddUserPostVoteAsync(request);

        return StatusCode(201);
    }
}