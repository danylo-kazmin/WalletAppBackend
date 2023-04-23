

namespace WalletAppBackend.Infrastructure.DataAccess.Contracts
{
    public interface IDbRepository
    {
        Task<T> Get<T>(Guid id) where T : class, IEntity;
        Task<IEnumerable<T>> GetAll<T>() where T : class, IEntity;
        Task<T> AddAsync<T>(T newEntity) where T : class, IEntity;
        Task<bool> RemoveAsync<T>(Guid id) where T : class, IEntity;
        Task<bool> UpdateAsync<T>(T entity) where T : class, IEntity;
        Task<int> SaveChangesAsync();
    }
}
