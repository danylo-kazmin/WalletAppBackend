using Microsoft.EntityFrameworkCore;
using WalletAppBackend.Infrastructure.DataAccess.Contracts;
using WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.Repositories
{
    public class DbRepository : IDbRepository
    {
        private readonly WalletDbContext _context;

        public DbRepository(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
            where T : class, IEntity
        {
            var result = await _context.Set<T>().AsQueryable().ToListAsync();

            return result;
        }

        public async Task<T> GetByIdAsync<T>(Guid id)
            where T : class, IEntity
        {
            var result = await _context.Set<T>().AsQueryable().FirstOrDefaultAsync(e => e.Id == id);

            return result;
        }

        public async Task<T> GetByDayAsync<T>(int dayOfSeasone)
            where T : class, IEntity
        {
            var result = await _context.Set<DailyPointsEntity>().AsQueryable().FirstOrDefaultAsync(e => e.DayOfSeasone == dayOfSeasone);

            return result as T;
        }

        public async Task<T> GetByUsernameAsync<T>(string username)
            where T : class, IEntity
        {
            var result = await _context.Set<UserEntity>().AsQueryable().FirstOrDefaultAsync(e => e.Username == username);

            return result as T;
        }

        public async Task<List<T>> GetAllByUserIdAsync<T>(Guid userId) 
            where T : class, IEntityForUser
        {
            var result = await _context.Set<T>().AsQueryable().Where(e => e.UserId == userId).ToListAsync();

            return result;
        }

        public async Task<T> AddAsync<T>(T newEntity)
            where T : class, IEntity
        {
            var result = await _context.Set<T>().AddAsync(newEntity);

            if (result != null)
            {
                await SaveChangesAsync();
                return result.Entity;
            }

            return null;
        }

        public async Task<List<T>> AddRangeAsync<T>(List<T> entities) 
            where T : class, IEntity
        {
            if (entities == null || entities.Count == 0)
            {
                return null;
            }

            await _context.Set<T>().AddRangeAsync(entities);
            await SaveChangesAsync();

            return entities;
        }

        public async Task<bool> RemoveAsync<T>(Guid id)
            where T : class, IEntity
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(u => u.Id == id);

            if (result != null)
            {
                _context.Remove(result);
                await SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAsync<T>(T entity)
            where T : class, IEntity
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(u => u.Id == entity.Id);

            if (result != null)
            {
                _context.Set<T>().Update(entity);
                await SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
