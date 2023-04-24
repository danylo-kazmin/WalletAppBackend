

namespace WalletAppBackend.Infrastructure.DataAccess.Contracts
{
    public interface IDbRepository
    {
        Task<T> GetByIdAsync<T>(Guid id) where T : class, IEntity;
        Task<T> GetByDayAsync<T>(int dayOfSeasone) where T : class, IEntity;
        Task<T> GetByUsernameAsync<T>(string username) where T : class, IEntity;
        Task<List<T>> GetAllByUserIdAsync<T>(Guid userId) where T : class, IEntityForUser;
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class, IEntity;
        Task<T> AddAsync<T>(T newEntity) where T : class, IEntity;
        Task<List<T>> AddRangeAsync<T>(List<T> entities) where T : class, IEntity;
        Task<bool> RemoveAsync<T>(Guid id) where T : class, IEntity;
        Task<bool> UpdateAsync<T>(T entity) where T : class, IEntity;
        Task<int> SaveChangesAsync();
    }
}
