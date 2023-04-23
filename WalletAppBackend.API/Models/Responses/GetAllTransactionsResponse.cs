using WalletAppBackend.Service.Models;

namespace WalletAppBackend.API.Models.Responses
{
    public class GetAllTransactionResponse
    {
        public List<Transaction> Transactions { get; set; }
    }
}
