using WalletAppBackend.Service.Models;

namespace WalletAppBackend.Service.Models.Responses
{
    public class GetAllUsersResponse
    {
        public List<User> Users { get; set; }
    }
}
