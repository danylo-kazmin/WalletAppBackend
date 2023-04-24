

using WalletAppBackend.Infrastructure.DataAccess.Contracts;

namespace WalletAppBackend.Service.Models
{
    public class TrustedPerson : IEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
