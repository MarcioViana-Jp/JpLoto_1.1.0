using JpLoto.Application.Dto.Request;
using JpLoto.Application.Dto.Response;
using System.Net.Http.Json;

namespace JpLoto.Site.Services.Account;

public class AccountService : IAccountService
{
    private readonly HttpClient _http;
    private readonly AuthenticationStateProvider _authStateProvider;

    public AccountService(HttpClient http, AuthenticationStateProvider authStateProvider)
    {
        _http = http;
        _authStateProvider = authStateProvider;
    }

    public async Task<RegisterResponseData> ChangePassword(ChangePasswordRequest request)
    {
        var result = await _http.PostAsJsonAsync("https://localhost:7125/api/account/changepassword", request);
        var response = await result.Content.ReadFromJsonAsync<RegisterResponseData>();
        return response;
    }

    public async Task<bool> IsUserAuthenticated()
    {
        bool isAuthenticated = (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        return isAuthenticated;
    }

    public async Task<LoginResponseData> Login(LoginRequest request)
    {
        var result = await _http.PostAsJsonAsync("https://localhost:7125/api/account/login", request);
        return await result.Content.ReadFromJsonAsync<LoginResponseData>();
    }

    public async Task<RegisterResponseData> Register(RegisterRequest request)
    {
        var result = await _http.PostAsJsonAsync("https://localhost:7125/api/account/register", request);
        return await result.Content.ReadFromJsonAsync<RegisterResponseData>();
    }

    public async Task<bool> ResendConfirmationEmail(EmailRequest request)
    {
        await _http.PostAsJsonAsync("https://localhost:7125/api/account/resendemail", request);
        return true;
    }

    public string GetCurrentUser()
    {
        return string.Empty;
    }

    public async Task Logout()
    {
        await _http.GetAsync("https://localhost:7125/api/account/logout");
        return;
    }

}

