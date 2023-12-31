using JpLoto.Domain.Entities.Shared;
using JpLoto.Domain.Interfaces.Repositories.Shared;
using JpLoto.Domain.Interfaces.Services.Shared;

namespace JpLoto.Domain.Services.Shared;

public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : Entity
{
    private readonly IRepositoryBase<TEntity> _repositoryBase;

    public ServiceBase(IRepositoryBase<TEntity> repositoryBase) =>
        _repositoryBase = repositoryBase;

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync() =>
        await _repositoryBase.GetAllAsync();

    public virtual async Task<TEntity?> GetByIdAsync(int id) =>
        await _repositoryBase.GetByIdAsync(id);

    public virtual async Task<object> AddAsync(TEntity objeto) =>
        await _repositoryBase.AddAsync(objeto);

    public virtual async Task UpdateAsync(TEntity objeto) =>
        await _repositoryBase.UpdateAsync(objeto);
    
    public virtual async Task RemoveAsync(TEntity objeto) =>
        await _repositoryBase.RemoveAsync(objeto);

    public virtual async Task RemoveByIdAsync(int id) =>
        await _repositoryBase.RemoveByIdAsync(id);

    public void Dispose() =>
        _repositoryBase.Dispose();
}