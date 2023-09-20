using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories;
using JpLoto.Domain.Interfaces.Services;
using JpLoto.Domain.Services.Shared;

namespace JpLoto.Domain.Services;

public class TrialService : ServiceBase<Trial>, ITrialService
{
    private readonly ITrialRepository _trialRepository;
    public TrialService(ITrialRepository trialRepository) : base(trialRepository)
    {
        _trialRepository = trialRepository;
    }

    public virtual async Task<Trial> GetByUserIdAsync(string userId) =>
        await _trialRepository.GetByUserIdAsync(userId);
}

