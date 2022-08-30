using API.Data.Dtos.UserCommunity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserCommunityController : ControllerBase
{
    private readonly IUserCommunityService _service;

    public UserCommunityController(IUserCommunityService service)
    {
        _service = service;
    }

    [HttpGet("{communityId}/{userId}")]
    public async Task<IActionResult> GetUserCommunityByUserIdAsync(int userId, int communityId)
    {
        var result = await _service.GetUserCommunityByUserIdAsync(userId, communityId);
        if (result == null) return NotFound();

        return Ok(result);
    }

    [HttpGet("User/{userId}")]
    public async Task<IActionResult> GetUserJoinedCommunitiesByUserIdAsync(int userId)
    {
        var result = await _service.GetUserJoinedCommunitiesByUserIdAsync(userId);
        if (!result.Any()) return NotFound();

        return Ok(result);
    }

    [HttpGet("Admin/{userId}")]
    public async Task<IActionResult> GetUserAdminCommunitiesByUserIdAsync(int userId)
    {
        var result = await _service.GetUserAdminCommunitiesByUserIdAsync(userId);
        if (!result.Any()) return NotFound();

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> JoinOrLeaveCommunityByUserIdAsync(
        [FromBody] UserCommunityCreateDto userCommunityCreateDto)
    {
        var result = await _service.JoinOrLeaveCommunityByUserIdAsync(userCommunityCreateDto);

        if (!result) return BadRequest("Update failed!");

        return NoContent();
    }
}