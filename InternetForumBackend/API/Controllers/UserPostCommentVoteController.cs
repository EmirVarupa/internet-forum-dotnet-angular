using API.Data.Dtos.UserPostCommentVote;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserPostCommentVoteController : Controller
{
    private readonly IUserPostCommentVoteService _service;

    public UserPostCommentVoteController(IUserPostCommentVoteService service)
    {
        _service = service;
    }

    //TODO: remove httput ID and id from methods
    [HttpPut]
    public async Task<IActionResult> IncrementPostCommentVoteWithUserIdAsync([FromBody] UserPostCommentVoteDto userPostCommentVoteDto)
    {
        var result = await _service.IncrementOrDecrementPostCommentVoteWithUserIdAsync(userPostCommentVoteDto);

        if (result == null) return BadRequest("Update failed!");

        return Ok(result);
    }

    [HttpGet("User/{userId}")]
    public async Task<IActionResult> GetUserPostCommentVotesByUserIdAsync(int userId)
    {
        var result = await _service.GetUserPostCommentVotesByUserIdAsync(userId);
        if (!result.Any()) return NotFound();

        return Ok(result);
    }

    [HttpGet("User/{postCommentId}")]
    public async Task<IActionResult> GetUserPostCommentVotesByPostIdAsync(int postCommentId)
    {
        var result = await _service.GetUserPostCommentVotesByUserIdAsync(postCommentId);
        if (!result.Any()) return NotFound();

        return Ok(result);
    }

    [HttpGet("User")]
    public async Task<IActionResult> GetUserPostCommentVotesByPostAndUserIdAsync(int userId, int postCommentId)
    {
        var result = await _service.GetUserPostCommentVotesByPostCommentAndUserIdAsync(userId, postCommentId);
        if (!result.Any()) return NotFound();

        return Ok(result);
    }

    [HttpPost("AddUserPostVoteAsync")]
    public async Task<ActionResult<UserPostCommentVoteDto>> AddUserPostCommentVoteAsync(UserPostCommentVoteDto request)
    {
        await _service.AddUserPostCommentVoteAsync(request);

        return StatusCode(201);
    }
}
