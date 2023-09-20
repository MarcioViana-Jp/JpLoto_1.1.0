using Microsoft.EntityFrameworkCore;
using JpLoto.Data.Context;
using JpLoto.Domain.Entities.Shared;
using JpLoto.Domain.Interfaces.Repositories.Shared;

namespace JpLoto.Data.Repositories.Shared;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
{
    protected readonly DataContext Context;

    public RepositoryBase(DataContext dataContext) =>
        Context = dataContext;

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync() =>
        await Context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();

    public virtual async Task<TEntity?> GetByIdAsync(int id) =>
        await Context.Set<TEntity>().FindAsync(id);

    public virtual async Task<object> AddAsync(TEntity objeto)
    {
        Context.Add(objeto);
        await Context.SaveChangesAsync();
        return objeto.Id;
    }

    public virtual async Task UpdateAsync(TEntity objeto)
    {
        Context.Entry(objeto).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }
    
    public virtual async Task RemoveAsync(TEntity objeto)
    {
        Context.Set<TEntity>().Remove(objeto);
        await Context.SaveChangesAsync();
    }

    public virtual async Task RemoveByIdAsync(int id)
    {
        var objeto = await GetByIdAsync(id);
        //if (objeto == null)
        //    throw new Exception("O registro não existe na base de dados.");
        //await RemoveAsync(objeto);
        if (objeto != null)
            await RemoveAsync(objeto);
    }

    public void Dispose() =>
        Context.Dispose();
}