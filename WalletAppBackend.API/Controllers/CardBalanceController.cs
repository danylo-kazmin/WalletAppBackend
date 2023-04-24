using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WalletAppBackend.Service.Helpers;
using WalletAppBackend.Service.Models.Requests;
using WalletAppBackend.Service.Models.Responses;
using WalletAppBackend.Service.Services.Abstractions;

namespace WalletAppBackend.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class CardBalanceController : ControllerBase
    {
        private readonly ICardBalanceService _cardBalanceService;

        public CardBalanceController(ICardBalanceService cardBalanceService)
        {
            _cardBalanceService = cardBalanceService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromBody] GetCardBalanceRequest request)      
        {
            try
            {
                var result = await _cardBalanceService.GetByIdAsync(request);

                return Ok(result);
            }
            catch (Service.Helpers.KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
