

namespace WalletAppBackend.Service.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public User User { get; set; }
        public TrustedPerson TrustedPerson { get; set; }
    }
}
