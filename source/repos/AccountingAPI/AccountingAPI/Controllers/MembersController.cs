using LoanManagementSystemApplication.Dtos;
using LoanManagementSystemApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {

        private readonly MemberService _service;

        public MembersController(MemberService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MemberDto dto)
        {
            var id = await _service.CreateMemberAsync(dto);
            return Ok(new { Id = id });
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MemberDto dto)
        {
            dto.Id = id;
            var updated = await _service.UpdateMemberAsync(dto);
            return Ok(new { Updated = updated });
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteMemberAsync(id);
            return Ok(new { Deleted = deleted });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var members = await _service.GetAllMembersAsync();
            return Ok(members);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? nationalCode, [FromQuery] string? fullName)
        {
            var members = await _service.SearchMembersAsync(nationalCode, fullName);
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var member = await _service.GetMemberByIdAsync(id);
            if (member == null) return NotFound();
            return Ok(member);
        }
    }
}
    

