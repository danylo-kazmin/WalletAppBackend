

namespace WalletAppBackend.Service.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public string DailyPoints { get; set; }
        public string IconLink { get; set; }
        public List<Guid> CoOwnerIds { get; set; }
        public List<Transaction> Transactions { get; set; }
        public CardBalance CardBalance { get; set; }
    }
}
