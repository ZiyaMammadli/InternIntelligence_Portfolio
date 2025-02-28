using Microsoft.EntityFrameworkCore.Query;
using Portfolio.Application.Interfaces.Repositories;
using Portfolio.Domain.Entities.Common;
using System.Linq.Expressions;

namespace Portfolio.Persistence.Repositories;

public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : class, IBaseEntity, new()
{
    public Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression, bool enableTracking = false)
    {
        throw new NotImplementedException();
    }

    public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, bool enableTracking = false)
    {
        throw new NotImplementedException();
    }

    public Task<List<TEntity>> GetAllByPaginatedAsync(Expression<Func<TEntity, bool>>? expression = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderedBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>>? expression = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = false)
    {
        throw new NotImplementedException();
    }
}
