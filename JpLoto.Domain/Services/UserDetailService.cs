using JpLoto.Domain.Entities;
using JpLoto.Domain.Interfaces.Repositories;
using JpLoto.Domain.Interfaces.Services;
using JpLoto.Domain.Services.Shared;

namespace JpLoto.Domain.Services;

public class UserDetailService : ServiceBase<JplUserDetail>, IUserDetailService
{
    private readonly IUserDetailRepository _userDetailRepository;
    public UserDetailService(IUserDetailRepository userDetailRepository) : base(userDetailRepository) 
    { 
        _userDetailRepository = userDetailRepository;
    }
    public virtual async Task<JplUserDetail> GetByUserIdAsync(string userId) =>
        await _userDetailRepository.GetByUserIdAsync(userId);

}