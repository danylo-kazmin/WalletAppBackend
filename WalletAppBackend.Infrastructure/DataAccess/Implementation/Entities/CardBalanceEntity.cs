using WalletAppBackend.Infrastructure.DataAccess.Contracts;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities
{
    public class CardBalanceEntity : IEntity, IEntityForUser
    {
        public Guid Id { get; set; }
        public decimal MaxLimit { get; set; }
        public decimal Balance { get; set; }
        public string PaymentMessage { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
