using GrowthMap.Domain.Repositories;
using GrowthMap.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GrowthMap.Persistence.Repositories
{
    public class BaseRepository<T>: IAsyncRepository<T> where T : class
    {
        private readonly GrowthMapDbContext _context;

        public BaseRepository(GrowthMapDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var entry = _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(Guid id)
            => await _context.Set<T>().FindAsync(id);

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
