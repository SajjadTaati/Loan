using LoanManagementSystemApplication.Dtos;
using LoanManagementSystemApplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _auth;

        public AuthController(IAuthService auth) => _auth = auth;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req)
        {
            try
            {
                var id = await _auth.RegisterAsync(req.Username, req.Password, req.Role);
                return Ok(new { Id = id });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var token = await _auth.AuthenticateAsync(req.Username, req.Password);
            if (token == null) return Unauthorized();
            return Ok(token);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnly()
        {
            return Ok();
        }

        [Authorize(Roles = "Member")]
        [HttpGet("member-test")]
        public IActionResult MemberTest()
        {
          return  Ok(" فقط Member به این endpoint دسترسی دارد");
        }
    }
}

