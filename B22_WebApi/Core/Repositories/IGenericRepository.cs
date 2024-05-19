
using Core.Entities;
using System.Linq.Expressions;

namespace Core.Repositories;

// Generic Repository Interface for all repos to follow, carrying the base functionality
public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetByIdAsync(Guid id);
    Task CreateAsync(TEntity entity);
    void Update(TEntity entity);
    Task DeleteAsync(Guid id);

    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

    Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);

    Task<IEnumerable<TEntity>> GetAllPaginatedAsync(int pageNumber, int pageSize, params Expression<Func<TEntity, object>>[] includes);

    Task<(IEnumerable<TEntity> Items, int TotalPages)> FindPaginatedAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize, params Expression<Func<TEntity, object>>[] includes);
}
