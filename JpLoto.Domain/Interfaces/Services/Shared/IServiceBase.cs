using JpLoto.Domain.Entities.Shared;

namespace JpLoto.Domain.Interfaces.Services.Shared;

public interface IServiceBase<TEntity> : IDisposable where TEntity : Entity
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task<object> AddAsync(TEntity objeto);
    Task UpdateAsync(TEntity objeto);
    Task RemoveAsync(TEntity objeto);
    Task RemoveByIdAsync(int id);
}
