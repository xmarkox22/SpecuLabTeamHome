using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PrototipoApi.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            params Expression<Func<T, object>>[] includes
        );

        Task<T?> GetOneAsync(Expression<Func<T, bool>> predicate,
                     params Expression<Func<T, object>>[] includes);
        Task<TResult?> SelectOneAsync<TResult>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, TResult>> selector,
            CancellationToken ct = default,
            bool asNoTracking = true
        );

        Task<List<TResult>> SelectListAsync<TResult>(
            Expression<Func<T, bool>>? filter,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
            Expression<Func<T, TResult>> selector,
            int? skip = null,
            int? take = null,
            CancellationToken ct = default,
            bool asNoTracking = true
        );

        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> ExistsAsync(int id);
        public Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken ct = default);

        Task<int> CountAsync(Expression<Func<T, bool>>? filter = null, CancellationToken ct = default);


        Task SaveChangesAsync();
    }

}
