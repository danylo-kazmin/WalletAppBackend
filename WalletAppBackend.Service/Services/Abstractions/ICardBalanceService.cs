using WalletAppBackend.Service.Models;
using WalletAppBackend.Service.Models.Responses;

namespace WalletAppBackend.Service.Services.Abstractions
{
    public interface ICardBalanceService
    {
        Task<GetCardBalanceResponse> GetByIdAsync(Guid id);
        Task<CardBalance> AddAsync(Guid userId, decimal amount = 1500);
    }
}
