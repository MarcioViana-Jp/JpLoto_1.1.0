using JpLoto.Application.Dto.Request;
using JpLoto.Application.Dto.Response;

namespace JpLoto.Application.Interfaces.Services;

public interface IIdentityService
{
    Task<RegisterResponseApplication> RegisterNewUser(RegisterRequestApplication usuarioCadastro);
    Task<RegisterResponseApplication> ChangePassword(ChangePasswordRequestApplication changePswRequest);
    Task<LoginResponseApplication> Login(LoginRequestApplication usuarioLogin);
    Task Logout();
    Task<LoginResponseApplication> RefreshToken(string usuarioId);
}