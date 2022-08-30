using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.UserStatus;
using API.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserStatusController : ControllerBase
{
    private readonly IUserStatusService _service;

    public UserStatusController(IUserStatusService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserStatusAsync()
    {
        var result = await _service.GetUserStatusAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserStatusByIdAsync(int id)
    {
        var userStatus = await _service.GetUserStatusByIdAsync(id);

        if (userStatus == null) return NotFound();

        return Ok(userStatus);
    }

    [HttpPost]
    public async Task<IActionResult> AddUserStatusAsync([FromBody] UserStatusCreateDto userStatusCreateDto)
    {
        await _service.AddUserStatusAsync(userStatusCreateDto);

        return StatusCode(201);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserStatusAsync(int id,
        [FromBody] UserStatusUpdateDto userStatusUpdateDto)
    {
        var result = await _service.UpdateUserStatusAsync(id, userStatusUpdateDto);

        if (!result) return BadRequest("Update failed!");

        return NoContent();
    }
}