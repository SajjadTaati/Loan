using LoanManagementSystem.Domain.Entities;
using LoanManagementSystemApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly LoanService _service;

        public LoanController(LoanService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetLoansAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Loan loan)
        {
            var id = await _service.AddLoanAsync(loan);
            return Ok(new { Id = id });
        }
    }
}
