using WalletAppBackend.Service.Models;

namespace WalletAppBackend.Service.Models.Responses
{
    public class GetAllTransactionResponse
    {
        public List<Transaction> Transactions { get; set; }
    }
}
