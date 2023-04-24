using WalletAppBackend.Service.Models;
using WalletAppBackend.Service.Models.Requests;
using WalletAppBackend.Service.Models.Responses;

namespace WalletAppBackend.Service.Services.Abstractions
{
    public interface ICardBalanceService
    {
        Task<GetCardBalanceResponse> GetByIdAsync(GetCardBalanceRequest request);
        Task<CardBalance> AddAsync(Guid userId, int amount = 1500);
    }
}
