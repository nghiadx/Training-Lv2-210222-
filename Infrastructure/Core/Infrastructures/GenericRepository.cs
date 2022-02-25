using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace Infrastructure.Core.Infrastructures
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
    {
        protected readonly DatabaseContext _context;
        private DbSet<TEntity> _dbset;
        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }
        public async Task Add(TEntity entity)
        {
            _dbset.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _dbset.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(TEntity entity)
        {
            _dbset.Update(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<TEntity> Get(int? id)
        {
            return await _dbset.FindAsync(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbset.ToList();
        }
    }
}
