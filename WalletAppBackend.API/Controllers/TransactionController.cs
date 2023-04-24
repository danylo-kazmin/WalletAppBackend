using Microsoft.AspNetCore.Mvc;
using WalletAppBackend.Service.Helpers;
using WalletAppBackend.Service.Models.Requests;
using WalletAppBackend.Service.Services.Abstractions;

namespace WalletAppBackend.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] GetTransactionRequest request)
        {
            try
            {
                var response = await _transactionService.GetByIdAsync(request);

                return Ok(response);
            }
            catch (Service.Helpers.KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByUserIdAsync([FromQuery] GetAllTransactionsByUserIdRequest request)
        {
            try
            {
                var response = await _transactionService.GetAllByUserIdAsync(request);

                return Ok(response);
            }
            catch (Service.Helpers.KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateTransactionRequest request)
        {
            try
            {
                var response = await _transactionService.AddAsync(request);

                return CreatedAtAction(nameof(GetByIdAsync), new { id = response.Id }, response);
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
