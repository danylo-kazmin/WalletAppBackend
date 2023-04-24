

namespace WalletAppBackend.Infrastructure.DataAccess.Contracts
{
    public interface IEntityForUser
    {
        public Guid UserId { get; set; }
    }
}
