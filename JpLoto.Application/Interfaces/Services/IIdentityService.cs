using JpLoto.Application.Dto.Request;
using JpLoto.Application.Dto.Response;
using Microsoft.AspNetCore.Identity;

namespace JpLoto.Application.Interfaces.Services;

public interface IIdentityService
{
    Task<RegisterResponse> RegisterNewUser(RegisterRequest usuarioCadastro);
    Task<RegisterResponse> ChangePassword(ChangePasswordRequest changePswRequest);
    Task<LoginResponse> Login(LoginRequest usuarioLogin);
    Task Logout();
    Task<IdentityUser> GetUserByEmailAsync(string email);
    Task<LoginResponse> RefreshToken(string usuarioId);
}