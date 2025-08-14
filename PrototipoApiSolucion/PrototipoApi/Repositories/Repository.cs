namespace PrototipoApi.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PrototipoApi.BaseDatos;
    using PrototipoApi.Repositories.Interfaces;
    using System.Linq.Expressions;
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ContextoBaseDatos _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ContextoBaseDatos context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetOneAsync(Expression<Func<T, bool>> predicate,
                                  params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            foreach (var include in includes)
                query = query.Include(include);

            return await query.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<T>> GetAllAsync(
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            params Expression<Func<T, object>>[] includes
        )
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            foreach (var include in includes)
                query = query.Include(include);

            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync();
        }

        public async Task<TResult?> SelectOneAsync<TResult>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, TResult>> selector,
            CancellationToken ct = default,
            bool asNoTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (asNoTracking) query = query.AsNoTracking();

            return await query
                .Where(filter)
                .Select(selector)
                .FirstOrDefaultAsync(ct);
        }

        public async Task<List<TResult>> SelectListAsync<TResult>(
            Expression<Func<T, bool>>? filter,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
            Expression<Func<T, TResult>> selector,
            int? skip = null,
            int? take = null,
            CancellationToken ct = default,
            bool asNoTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (asNoTracking) query = query.AsNoTracking();
            if (filter != null) query = query.Where(filter);
            if (orderBy != null) query = orderBy(query);
            if (skip.HasValue) query = query.Skip(skip.Value);
            if (take.HasValue) query = query.Take(take.Value);

            return await query.Select(selector).ToListAsync(ct);
        }

        public async Task<T?> GetByIdAsync(int id) =>
            await _dbSet.FindAsync(id);

        public async Task AddAsync(T entity) =>
            await _dbSet.AddAsync(entity);

        public Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(int id) =>
            await _dbSet.FindAsync(id) != null;

        public Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken ct = default) => _dbSet.AnyAsync(filter, ct);

        public Task<int> CountAsync(Expression<Func<T, bool>>? filter = null, CancellationToken ct = default)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null) query = query.Where(filter);
            return query.CountAsync(ct);
        }

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }

}
