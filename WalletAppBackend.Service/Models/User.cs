

namespace WalletAppBackend.Service.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public List<Transaction> Transactions { get; set; }
        public DailyPoints DailyPoints { get; set; }
        public CardBalance CardBalance { get; set; }
    }
}
