using Portfolio.Application.Interfaces.Repositories;
using Portfolio.Domain.Entities.Common;

namespace Portfolio.Application.Interfaces.UnitOfWorks;

public interface IUnitOfWork:IDisposable
{
    public IWriteRepository<TEntity> GetWriteRepository<TEntity>() where TEntity : class, IBaseEntity, new();
    public IReadRepository<TEntity> GetReadRepository<TEntity>() where TEntity:class,IBaseEntity,new();
    public Task<int> SaveAsync();
    public int Save();
}
