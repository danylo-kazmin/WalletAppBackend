using Microsoft.AspNetCore.Mvc;
using WalletAppBackend.Service.Helpers;
using WalletAppBackend.Service.Models;
using WalletAppBackend.Service.Models.Requests;
using WalletAppBackend.Service.Services;
using WalletAppBackend.Service.Services.Abstractions;

namespace WalletAppBackend.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _userService.GetAllAsync();

                return Ok(result);
            }
            catch (Service.Helpers.KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromBody] GetUserRequest request)
        {
            try
            {
                var result = await _userService.GetByIdAsync(request);

                return Ok(result);
            }
            catch (Service.Helpers.KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateUserRequest request)
        {
            try
            {
                var result = await _userService.AddAsync(request);

                return Ok(result);
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
