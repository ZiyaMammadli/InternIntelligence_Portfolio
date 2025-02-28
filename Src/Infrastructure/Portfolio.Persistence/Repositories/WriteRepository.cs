using Portfolio.Application.Interfaces.Repositories;
using Portfolio.Domain.Entities.Common;

namespace Portfolio.Persistence.Repositories;

public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : class, IBaseEntity, new()
{
    public Task AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task AddRangeAsync(List<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public void Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
