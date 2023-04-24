using WalletAppBackend.Service.Models;

namespace WalletAppBackend.Service.Models.Responses
{
    public class GetAllTransactionsResponse
    {
        public List<Transaction> Transactions { get; set; }
    }
}
