using Microsoft.EntityFrameworkCore.Query;
using Portfolio.Domain.Entities.Common;
using System.Linq.Expressions;

namespace Portfolio.Application.Interfaces.Repositories;

public interface IReadRepository<TEntity> where TEntity : class, IBaseEntity, new()
{
    public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            bool enableTracking = false);
    public Task<List<TEntity>> GetAllByPaginatedAsync(Expression<Func<TEntity, bool>>? expression = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderedBy = null,
            bool enableTracking = false, int currentPage = 1, int pageSize = 3);
    public Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>>? expression = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool enableTracking = false);
    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression, bool enableTracking = false);
    public Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null);
}
