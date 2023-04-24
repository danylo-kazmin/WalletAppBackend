

namespace WalletAppBackend.Service.Models
{
    public class CardBalance
    {
        public Guid Id { get; set; }
        public decimal MaxLimit { get; set; }
        public decimal Balance { get; set; }
        public string PaymentMessage { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
