using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories.Shared;

namespace JpLoto.Domain.Interfaces.Repositories
{
    public interface ITrialRepository : IRepositoryBase<Trial>
    {
        Task<Trial> GetByUserIdAsync(string userId);
    }
}
