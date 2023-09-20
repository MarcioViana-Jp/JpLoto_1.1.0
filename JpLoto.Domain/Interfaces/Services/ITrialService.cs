using JpLoto.Domain.Entities;
using JpLoto.Domain.Entities.Shared;
using JpLoto.Domain.Interfaces.Services.Shared;

namespace JpLoto.Domain.Interfaces.Services;

public interface ITrialService : IServiceBase<Trial>
{
    Task<Trial> GetByUserIdAsync(string userId);
}
