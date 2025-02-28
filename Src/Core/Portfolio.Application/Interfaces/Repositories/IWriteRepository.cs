using Portfolio.Domain.Entities.Common;

namespace Portfolio.Application.Interfaces.Repositories;

public interface IWriteRepository<TEntity> where TEntity : class, IBaseEntity, new()
{
    public Task AddAsync(TEntity entity);
    public Task AddRangeAsync(List<TEntity> entities);
    public Task<TEntity> UpdateAsync(TEntity entity);
    public void Delete(TEntity entity);
}
