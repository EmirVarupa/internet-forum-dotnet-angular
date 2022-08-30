using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.User;
using API.Data.Models;
using API.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync()
    {
        var result = await _service.GetUsersAsync();

        return Ok(result);
    }

    [HttpGet("Community/{communityId}")]
    public async Task<IActionResult> GetUsersFromCommunityAsync(int communityId)
    {
        var result = await _service.GetUsersFromCommunityAsync(communityId);

        return Ok(result);
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> GetUserByUsernameAsync(string username)
    {
        var UserByUsername = await _service.GetUserByUsernameAsync(username);
        if (UserByUsername == null) return NotFound();

        return Ok(UserByUsername);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterUserAsync([FromBody] UserDto userDto)
    {
        var response = await _service.RegisterUserAsync(userDto);
        return Ok(response);
    }

    [HttpPost("Login")]
    public async Task<ActionResult<UserDto>> LoginUserAsync(UserLoginDto request)
    {
        var response = await _service.LoginUserAsync(request);
        if (response.Success)
            return Ok(response);

        return BadRequest(response.Message);
    }

    [HttpPost("RefreshToken")]
    public async Task<ActionResult<string>> RefreshTokenAsync(string refreshToken)
    {
        var response = await _service.RefreshTokenAsync(refreshToken);
        if (response.Success)
            return Ok(response);

        return BadRequest(response.Message);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Editor,Admin")]
    public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UserUpdateDto userUpdateDto)
    {
        var result = await _service.UpdateUserByIdAsync(id, userUpdateDto);

        if (!result) return BadRequest("Update failed!");

        return NoContent();
    }

    [HttpPut("Archive/{userId}")]
    public async Task<IActionResult> ArchiveUserAsync(int userId)
    {
        var result = await _service.ArchiveUserByIdAsync(userId);

        if (!result) return BadRequest("Archive failed!");

        return NoContent();
    }
}