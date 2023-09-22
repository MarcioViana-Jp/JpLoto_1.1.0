using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories.Shared;

namespace JpLoto.Domain.Interfaces.Repositories;

public interface IUserDetailRepository : IRepositoryBase<JplUserDetail>
{
    Task<JplUserDetail> GetByUserIdAsync(string userId);
}
