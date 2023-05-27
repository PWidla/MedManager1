using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class EfGenericRepository<T, K> : IGenericRepository<T, K> where T : class, IIdentity<K> where K : IComparable<K>
    {
        private readonly DbSet<T> _dbSet;
        private readonly ApplicationDbContext _context;

        public EfGenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> Find(ISpecification<T> specification = null)
        {
            var query = _dbSet.AsQueryable();
            if (specification != null)
            {
                query = EFSpecificationEvaluator<T>.GetQuery(query, specification);
            }
            return query.ToList();
        }

        public async Task<T?> FindByIdAsync(K id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public T? FindById(K id)
        {
            return _dbSet.Find(id);
        }

        public List<T> FindAll()
        {
            return _dbSet.ToList();
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public void RemoveById(K id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public void Update(K id, T entity)
        {
            var existingEntity = _dbSet.Find(id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
        }

        public IEnumerable<T> FindBySpecification(ISpecification<T> specification = null)
        {
            var query = _dbSet.AsQueryable();
            if (specification != null)
            {
                query = EFSpecificationEvaluator<T>.GetQuery(query, specification);
            }
            return query.ToList();
        }
    }
}
