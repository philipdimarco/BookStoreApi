using BookStoreApi.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookStoreApi.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private BookStoreAppContext _appDbContext;
        internal DbSet<T> _dbSet;

        public BaseRepository(BookStoreAppContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            _dbSet = _appDbContext.Set<T>();
        }

        public async Task AddSingleAsync(T entityToAdd)
        {
            if (entityToAdd == null)
            {
                throw new ArgumentNullException(nameof(entityToAdd));
            }
            await _dbSet.AddAsync(entityToAdd);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
