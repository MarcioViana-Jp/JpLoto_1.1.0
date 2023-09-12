using JpLoto.Application.DTOs.Request;
using JpLoto.Application.DTOs.Response;

namespace JpLoto.Application.Interfaces.Services;

public interface IIdentityService
{
    Task<RegisterResponseApplication> RegisterNewUser(RegisterRequestApplication usuarioCadastro);
    Task<LoginResponseApplication> Login(LoginRequestApplication usuarioLogin);
    Task Logout();
    Task<LoginResponseApplication> RefreshToken(string usuarioId);
}