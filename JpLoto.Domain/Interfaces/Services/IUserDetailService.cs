using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Services.Shared;

namespace JpLoto.Domain.Interfaces.Services;

public interface IUserDetailService : IServiceBase<JplUserDetail>
{
    Task<JplUserDetail> GetByUserIdAsync(string userId);
}
