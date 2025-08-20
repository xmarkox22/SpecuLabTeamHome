using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PrototipoApi.Repositories.Interfaces
{
    // Interfaz de repositorio genérico para operaciones CRUD y consultas avanzadas
    public interface IRepository<T> where T : class
    {
        // Obtiene todas las entidades, permite ordenar e incluir relaciones
        Task<List<T>> GetAllAsync(
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            params Expression<Func<T, object>>[] includes
        );

        // Obtiene una entidad que cumpla el predicado, permitiendo incluir relaciones
        Task<T?> GetOneAsync(Expression<Func<T, bool>> predicate,
                     params Expression<Func<T, object>>[] includes);

        // Proyección de una entidad a un DTO, filtrando y seleccionando campos específicos
        Task<TResult?> SelectOneAsync<TResult>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, TResult>> selector,
            CancellationToken ct = default,
            bool asNoTracking = true
        );

        // Proyección de una lista de entidades a DTOs, con filtros, orden, paginación y selección de campos
        Task<List<TResult>> SelectListAsync<TResult>(
            Expression<Func<T, bool>>? filter,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
            Expression<Func<T, TResult>> selector,
            int? skip = null,
            int? take = null,
            CancellationToken ct = default,
            bool asNoTracking = true
        );

        // Busca una entidad por su clave primaria (ID)
        Task<T?> GetByIdAsync(int id);


        // Agrega una nueva entidad al contexto
        Task AddAsync(T entity);


        // Marca una entidad como modificada
        Task UpdateAsync(T entity);


        // Elimina una entidad del contexto
        Task DeleteAsync(T entity);


        // Verifica si existe una entidad con el ID dado
        Task<bool> ExistsAsync(int id);


        // Verifica si existe alguna entidad que cumpla el filtro
        public Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken ct = default);


        // Cuenta la cantidad de entidades que cumplen el filtro (o todas si es null)
        Task<int> CountAsync(Expression<Func<T, bool>>? filter = null, CancellationToken ct = default);


        // Guarda los cambios pendientes en la base de datos
        Task SaveChangesAsync();
    }

}
