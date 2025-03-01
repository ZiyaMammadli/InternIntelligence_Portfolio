using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Interfaces.Repositories;
using Portfolio.Domain.Entities.Common;
using Portfolio.Persistence.Contexts;

namespace Portfolio.Persistence.Repositories;

public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : class, IBaseEntity, new()
{
    private readonly PortfolioDbContext _DbContext;
    private DbSet<TEntity> DbTable { get => _DbContext.Set<TEntity>(); }

    public WriteRepository(PortfolioDbContext dbContext)
    {
        _DbContext = dbContext;
    }
    public async Task AddAsync(TEntity entity)
    {
        await DbTable.AddAsync(entity);
    }

    public async Task AddRangeAsync(List<TEntity> entities)
    {
        await DbTable.AddRangeAsync(entities);
    }

    public async void Delete(TEntity entity)
    {
        await Task.Run(() => DbTable.Remove(entity));
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        await Task.Run(() => DbTable.Update(entity));
        return entity;
    }
}
