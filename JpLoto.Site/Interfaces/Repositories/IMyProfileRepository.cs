using JpLoto.Application.Dto.Request;
using JpLoto.Application.Dto.Response;
using JpLoto.Domain.Entities;

namespace JpLoto.Site.Interfaces.Repositories;

public interface IMyProfileRepository
{
    event Action? OnChange;
    Task<IEnumerable<UserDetailResponse>> GetAllAsync();
    Task<UserDetailResponse?> GetByIdAsync(int id);
    Task<UserDetailResponse?> GetByUserIdAsync(string userId);
    Task<object> AddAsync(UserDetailAddRequest request);
    Task UpdateAsync(UserDetailUpdateRequest request);
    Task RemoveAsync(UserDetail userDetail);
    Task RemoveByIdAsync(int id);
}
