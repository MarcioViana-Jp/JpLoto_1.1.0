using JpLoto.Application.Dto.Request;
using JpLoto.Application.Dto.Response;

namespace JpLoto.Site.Services.Account
{
    public interface IAccountService
    {
        Task<LoginResponseData> Login(LoginRequest request);
        Task Logout();
        Task<RegisterResponseData> Register(RegisterRequest request);
        Task<RegisterResponseData> ChangePassword(ChangePasswordRequest request);
        Task<bool> IsUserAuthenticated();
        Task<bool> ResendConfirmationEmail(EmailRequest emailRequest);
    }
}
