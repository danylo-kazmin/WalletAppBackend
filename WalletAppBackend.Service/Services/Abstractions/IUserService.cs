using WalletAppBackend.Service.Models;
using WalletAppBackend.Service.Models.Requests;
using WalletAppBackend.Service.Models.Responses;

namespace WalletAppBackend.Service.Services.Abstractions
{
    public interface IUserService
    {
        Task<GetAllUsersResponse> GetAllAsync();
        Task<User> GetByIdAsync(GetUserRequest request);
        Task<CreateUserResponses> AddAsync(CreateUserRequest request);
    }
}
