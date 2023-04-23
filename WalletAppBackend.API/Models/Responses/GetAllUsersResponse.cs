using WalletAppBackend.Service.Models;

namespace WalletAppBackend.API.Models.Responses
{
    public class GetAllUsersResponse
    {
        public List<User> Users { get; set; }
    }
}
