using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Tag;
using API.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagController : ControllerBase
{
    private readonly ITagService _service;

    public TagController(ITagService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetTaskAsync()
    {
        var result = await _service.GetTagAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTagByIdAsync(int id)
    {
        var tag = await _service.GetTagByIdAsync(id);
        if (tag == null) return NotFound();

        return Ok(tag);
    }

    [HttpPost]
    public async Task<IActionResult> AddTagAsync([FromBody] TagCreateDto tagCreateDto)
    {
        await _service.AddTagAsync(tagCreateDto);

        return StatusCode(201);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTagAsync(int id, [FromBody] TagUpdateDto tagUpdateDto)
    {
        var result = await _service.UpdateTagAsync(id, tagUpdateDto);

        if (!result) return BadRequest("Update failed!");

        return NoContent();
    }
}