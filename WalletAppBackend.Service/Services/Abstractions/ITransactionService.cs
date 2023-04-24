using WalletAppBackend.Service.Models;
using WalletAppBackend.Service.Models.Requests;
using WalletAppBackend.Service.Models.Responses;

namespace WalletAppBackend.Service.Services.Abstractions
{
    public interface ITransactionService
    {
        Task<GetTransactionResponse> GetByIdAsync(GetTransactionRequest request);
        Task<GetAllTransactionsResponse> GetAllByUserIdAsync(GetAllTransactionsByUserIdRequest request);
        Task<Transaction> AddAsync(CreateTransactionRequest request);
    }
}
