using JpLoto.Application.DTOs.Request;
using JpLoto.Application.DTOs.Response;

namespace JpLoto.Application.Interfaces.Services;

public interface IIdentityService
{
    Task<RegisterResponse> RegisterNewUser(RegisterRequest usuarioCadastro);
    Task<LoginResponse> Login(LoginRequest usuarioLogin);
    Task<LoginResponse> RefreshToken(string usuarioId);
}