using JpLoto.Domain.Entities.Shared;

namespace JpLoto.Domain.Interfaces.Repositories.Shared;
    
public interface IRepositoryBase<TEntity> : IDisposable where TEntity : Entity
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task<object> AddAsync(TEntity objeto);
    Task UpdateAsync(TEntity objeto);
    Task RemoveAsync(TEntity objeto);
    Task RemoveByIdAsync(int id);
}