namespace WalletAppBackend.Service.Models.Requests
{
    public class GetAllTransactionsByUserIdRequest
    {
        public Guid UserId { get; set; }
    }
}
