
using Core.Entities;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace Core.Repositories;

// Generic Repository Implementation
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AppDbContext _context; // injecting db context

    public GenericRepository(AppDbContext context)
    {
        _context = context; // initalizing db context
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        var result = await _context.Set<TEntity>().FindAsync(id);
        if (result == null)
        {
            // throw not found exception
            throw new Exception();
        }
        return result;
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }



    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    // "predicate" is the param conditions applied on the transaction ex: obj => obj.age > 20
    // "includes" is the param values for relations to eager load navigation properites, ex: obj => obj.RelatedProperty
    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>().Where(predicate);

        if (includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        return await query.AsNoTracking().ToListAsync();
    }


    public async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();

        if (includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        
            return await query.ToListAsync();
        }

        return await query.AsNoTracking().ToListAsync();

    }

    public async Task<IEnumerable<TEntity>> GetAllPaginatedAsync(int pageNumber, int pageSize, params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();

        if (includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return await query.Skip((pageNumber - 1) * pageSize)
                         .Take(pageSize)
                         .ToListAsync();
    }


    public async Task<(IEnumerable<TEntity> Items, int TotalPages)> FindPaginatedAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize, params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>().Where(predicate);

        if (includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        int totalItems = await query.CountAsync();
        int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

        var items = await query.Skip((pageNumber - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync();

        return (items, totalPages);
    }


}