using WalletAppBackend.Infrastructure.DataAccess.Contracts;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities
{
    public class TrustedPersonEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
