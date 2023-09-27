using JpLoto.Data.JplContext;
using JpLoto.Data.Repositories.Shared;
using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JpLoto.Data.Repositories;

public class UserDetailRepository : RepositoryBase<UserDetail>, IUserDetailRepository
{
    private readonly DataContext _context;
    public UserDetailRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<UserDetail> GetByUserIdAsync(string userId) =>
           await _context.UserDetails.FirstOrDefaultAsync(p => p.UserId.Equals(userId));

}
