﻿using JpLoto.Application.Dto.Request;
using JpLoto.Application.Dto.Response;

namespace JpLoto.Site.Interfaces.Services
{
    public interface IAccountService
    {
        event Action? OnChange;
        Task<LoginResponseData> Login(LoginRequest request);
        Task Logout();
        Task<RegisterResponseData> Register(RegisterRequest request);
        Task<RegisterResponseData> ChangePassword(ChangePasswordRequest request);
        Task<bool> IsUserAuthenticated();
        Task<bool> ResendConfirmationEmail(EmailRequest emailRequest);
        Task<string> GetUserIdByEmailAsync(string email);
        Task<string> GetCurrentUserName();
    }
}
