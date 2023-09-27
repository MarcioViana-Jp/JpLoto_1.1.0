using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Services.Shared;

namespace JpLoto.Domain.Interfaces.Services;

public interface IUserDetailService : IServiceBase<UserDetail>
{
    Task<UserDetail> GetByUserIdAsync(string userId);
}
