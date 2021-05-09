using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Post;
using API.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPostAsync()
        {
            var result = await _service.GetPostsAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostByIdAsync(int id)
        {
            var tag = await _service.GetPostByIdAsync(id);
            if (tag == null) return NotFound();

            return Ok(tag);
        }

        [HttpPost]
        public async Task<IActionResult> AddPostAsync([FromBody] PostCreateDto postCreateDto)
        {
            await _service.AddPostAsync(postCreateDto);

            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePostAsync(int id, [FromBody] PostUpdateDto postUpdateDto)
        {
            var result = await _service.UpdatePostByIdAsync(id, postUpdateDto);

            if (!result) return BadRequest("Update failed!");

            return NoContent();
        }
    }
}
