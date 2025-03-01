using Microsoft.EntityFrameworkCore.Storage;
using Portfolio.Application.Interfaces.Repositories;
using Portfolio.Application.Interfaces.UnitOfWorks;
using Portfolio.Persistence.Contexts;
using Portfolio.Persistence.Repositories;

namespace Portfolio.Persistence.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly PortfolioDbContext _dbContext;

    public UnitOfWork(PortfolioDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public int Save()
    {
        return _dbContext.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    IReadRepository<TEntity> IUnitOfWork.GetReadRepository<TEntity>()
    {
        return new ReadRepository<TEntity>(_dbContext);
    }

    IWriteRepository<TEntity> IUnitOfWork.GetWriteRepository<TEntity>()
    {
        return new WriteRepository<TEntity>(_dbContext);
    }
}
