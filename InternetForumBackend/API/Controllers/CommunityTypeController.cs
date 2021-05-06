using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.CommunityType;
using API.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityTypeController : ControllerBase
    {
        private readonly ICommunityTypeService _service;

        public CommunityTypeController(ICommunityTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommunityTypeAsync()
        {
            var result = await _service.GetCommunityTypeAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommunityTypeByIdAsync(int id)
        {
            var userStatus = await _service.GetCommunityTypeByIdAsync(id);

            if (userStatus == null)
            {
                return NotFound();
            }

            return Ok(userStatus);
        }

        [HttpPost]
        public async Task<IActionResult> AddCommunityTypeAsync([FromBody] CommunityTypeCreateDto communityTypeCreateDto)
        {
            await _service.AddCommunityTypeAsync(communityTypeCreateDto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommunityTypeAsync(int id,
            [FromBody] CommunityTypeUpdateDto communityTypeUpdateDto)
        {
            var result = await _service.UpdateCommunityTypeAsync(id, communityTypeUpdateDto);

            if (!result)
            {
                return BadRequest("Update failed!");
            }

            return NoContent();
        }
    }
}
