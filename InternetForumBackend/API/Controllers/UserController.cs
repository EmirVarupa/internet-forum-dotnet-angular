using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.User;
using API.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
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
        public async Task<IActionResult> GetUserAsync()
        {
            var result = await _service.GetUsersAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var tag = await _service.GetUserByIdAsync(id);
            if (tag == null) return NotFound();

            return Ok(tag);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] UserCreateDto userCreateDto)
        {
            await _service.AddUserAsync(userCreateDto);

            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            var result = await _service.UpdateUserByIdAsync(id, userUpdateDto);

            if (!result) return BadRequest("Update failed!");

            return NoContent();
        }
    }
}
