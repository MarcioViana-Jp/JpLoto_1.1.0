using JPLoto.Domain.Dto.Request;
using JPLoto.Domain.Dto.Response;

namespace JpLoto.Site.Services.Account
{
    public interface IAccountService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<RegisterResponse> Register(RegisterRequest request);
        Task<RegisterResponse> ChangePassword(ChangePasswordRequest request);
        //Task<bool> IsUserAuthenticated();
        bool IsUserAuthenticated();
    }
}
