using JpLoto.Application.Dto.Request;
using JpLoto.Application.Dto.Response;

namespace JpLoto.Site.Services.Account
{
    public interface IAccountService
    {
        Task<LoginResponseData> Login(LoginRequestApplication request);
        Task Logout();
        Task<RegisterResponseData> Register(RegisterRequestApplication request);
        Task<RegisterResponseData> ChangePassword(ChangePasswordRequestApplication request);
        Task<bool> IsUserAuthenticated();
        Task<bool> ResendConfirmationEmail(EmailRequestApplication emailRequest);
    }
}
