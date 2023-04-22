
using WalletAppBackend.Infrastructure.DataAccess.Contracts;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities
{
    public class CardBalanceEntity : IEntity
    {
        public Guid Id { get; set; }
        public decimal MaxLimit { get; set; }
        public decimal Balance { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
