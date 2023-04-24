using WalletAppBackend.Service.Models;
using WalletAppBackend.Service.Models.Responses;

namespace WalletAppBackend.Service.Services.Abstractions
{
    public interface IUserService
    {
        Task<GetAllUsersResponse> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<CreateUserResponses> AddAsync(string username);
    }
}
