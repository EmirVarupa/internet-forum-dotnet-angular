using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Roles;
using API.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoleAsync()
        {
            var result = await _service.GetRoleAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleByIdAsync(int id)
        {
            var userStatus = await _service.GetRoleByIdAsync(id);

            if (userStatus == null) return NotFound();

            return Ok(userStatus);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleAsync([FromBody] RoleCreateDto roleCreateDto)
        {
            await _service.AddRoleAsync(roleCreateDto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoleAsync(int id,
            [FromBody] RoleUpdateDto roleUpdateDto)
        {
            var result = await _service.UpdateRoleAsync(id, roleUpdateDto);

            if (!result) return BadRequest("Update failed!");

            return NoContent();
        }
    }
}