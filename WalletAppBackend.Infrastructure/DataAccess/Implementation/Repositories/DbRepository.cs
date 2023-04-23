using Microsoft.EntityFrameworkCore;
using WalletAppBackend.Infrastructure.DataAccess.Contracts;

namespace WalletAppBackend.Infrastructure.DataAccess.Implementation.Repositories
{
    public class DbRepository : IDbRepository
    {
        private readonly WalletDbContext _context;

        public DbRepository(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll<T>()
            where T : class, IEntity
        {
            var result = await _context.Set<T>().AsQueryable().ToListAsync();

            if (result == null)
            {
                return null;
            }

            return result;
        }

        public async Task<T> Get<T>(Guid id)
            where T : class, IEntity
        {
            var entity = await _context.Set<T>().AsQueryable().FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null)
            {
                return null;
            }

            return entity;
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
