using JpLoto.Data.Context;
using JpLoto.Data.Repositories.Shared;
using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JpLoto.Data.Repositories;

public class TrialRepository : RepositoryBase<Trial>, ITrialRepository
{
    protected readonly DataContext _context;
    public TrialRepository(DataContext dataContext) : base(dataContext)
    {
        _context = dataContext;
    }

    public async Task<Trial> GetByUserIdAsync(string userId) =>    
           await _context.Trials.FirstOrDefaultAsync(p => p.UserId.Equals(userId));
    
}
