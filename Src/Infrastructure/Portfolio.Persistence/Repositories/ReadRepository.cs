using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Portfolio.Application.Interfaces.Repositories;
using Portfolio.Domain.Entities.Common;
using Portfolio.Persistence.Contexts;
using System.Linq.Expressions;

namespace Portfolio.Persistence.Repositories;

public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : class, IBaseEntity, new()
{
    private readonly PortfolioDbContext _DbContext;
    private DbSet<TEntity> DbTable { get => _DbContext.Set<TEntity>(); }

    public ReadRepository(PortfolioDbContext DbContext)
    {
        _DbContext = DbContext;
    }

    public Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null)
    {
        DbTable.AsNoTracking();
        return expression is not null
            ? DbTable.Where(expression).CountAsync()
            : DbTable.CountAsync();
    }

    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression, bool enableTracking = false)
    {
        var query=DbTable.AsQueryable();
        if(!enableTracking) query=query.AsNoTracking();
        return query.Where(expression); 
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, 
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, 
        bool enableTracking = false)
    {
        var query=DbTable.AsQueryable();
        if(!enableTracking) query=query.AsNoTracking();
        if(expression is not null) query=query.Where(expression);
        if (include is not null) query = include(query);
        if(orderBy is not null) return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }

    public async Task<List<TEntity>> GetAllByPaginatedAsync(Expression<Func<TEntity, bool>>? expression = null, 
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderedBy = null, 
        bool enableTracking = false, 
        int currentPage = 1, 
        int pageSize = 3)
    {
        var query= DbTable.AsQueryable();
        if(!enableTracking) query=query.AsNoTracking();
        if(expression is not null) query=query.Where(expression);
        if(include is not null) query=include(query);
        if(orderedBy is not null) return await orderedBy(query).Skip((currentPage - 1)*pageSize).Take(pageSize).ToListAsync();

        return await query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
    }
     
    public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>>? expression = null, 
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, 
        bool enableTracking = false)
    {
        var query = DbTable.AsQueryable();
        if(!enableTracking) query=query.AsNoTracking();
        if(expression is not null) query=query.Where(expression);
        if(include is not null) query=include(query);

        return await query.FirstOrDefaultAsync();
    }
}
