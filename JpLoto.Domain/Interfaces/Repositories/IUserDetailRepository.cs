using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories.Shared;

namespace JpLoto.Domain.Interfaces.Repositories;

public interface IUserDetailRepository : IRepositoryBase<UserDetail>
{
    Task<UserDetail> GetByUserIdAsync(string userId);
}
