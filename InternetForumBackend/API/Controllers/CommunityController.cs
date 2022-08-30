using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Community;
using API.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommunityController : ControllerBase
{
    private readonly ICommunityService _service;

    public CommunityController(ICommunityService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetCommunityAsync()
    {
        var result = await _service.GetCommunitiesAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCommunityByIdAsync(int id)
    {
        var tag = await _service.GetCommunityByIdAsync(id);
        if (tag == null) return NotFound();

        return Ok(tag);
    }

    [HttpPost]
    public async Task<IActionResult> AddCommunityAsync([FromBody] CommunityCreateDto communityCreateDto)
    {
        await _service.AddCommunityAsync(communityCreateDto);

        return StatusCode(201);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCommunityAsync(int id, [FromBody] CommunityUpdateDto communityUpdateDto)
    {
        var result = await _service.UpdateCommunityByIdAsync(id, communityUpdateDto);

        if (!result) return BadRequest("Update failed!");

        return NoContent();
    }

    [HttpPut("Archive/{communityId}")]
    public async Task<IActionResult> ArchiveCommunityAsync(int communityId)
    {
        var result = await _service.ArchiveCommunityByIdAsync(communityId);

        if (!result) return BadRequest("Archive failed!");

        return NoContent();
    }
}