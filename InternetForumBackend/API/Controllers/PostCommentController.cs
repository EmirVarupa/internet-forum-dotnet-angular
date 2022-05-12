﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.PostComment;
using API.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCommentController : ControllerBase
    {
        private readonly IPostCommentService _service;

        public PostCommentController(IPostCommentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPostCommentAsync()
        {
            var result = await _service.GetPostCommentsAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostCommentByIdAsync(int id)
        {
            var tag = await _service.GetPostCommentByIdAsync(id);
            if (tag == null) return NotFound();

            return Ok(tag);
        }

        [HttpGet("Post/{id}")]
        public async Task<IActionResult> GetPostCommentByPostIdAsync(int id)
        {
            var result = await _service.GetPostCommentByPostIdAsync(id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddPostCommentAsync([FromBody] PostCommentCreateDto postCommentCreateDto)
        {
            await _service.AddPostCommentAsync(postCommentCreateDto);

            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePostCommentAsync(int id, [FromBody] PostCommentUpdateDto postCommentUpdateDto)
        {
            var result = await _service.UpdatePostCommentByIdAsync(id, postCommentUpdateDto);

            if (!result) return BadRequest("Update failed!");

            return NoContent();
        }
    }
}
