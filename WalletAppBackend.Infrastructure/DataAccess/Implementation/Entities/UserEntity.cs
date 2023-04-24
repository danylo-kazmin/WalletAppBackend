using WalletAppBackend.Infrastructure.DataAccess.Contracts;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities
{
    public class UserEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string IconLink { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public List<TransactionEntity> Transactions { get; set; }
        public CardBalanceEntity CardBalance { get; set; }
    }
}
