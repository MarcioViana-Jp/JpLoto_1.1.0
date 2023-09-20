using Azure.Core;
using JpLoto.Application.Dto.Request;
using JpLoto.Application.Dto.Response;
using System.Net.Http.Json;

namespace JpLoto.Site.Services.Account;

public class AccountService : IAccountService
{
    public event Action? OnChange;
    private readonly HttpClient _http;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly ILocalStorageService _localStorage;

    public AccountService(HttpClient http, AuthenticationStateProvider authStateProvider, ILocalStorageService _localStorage)
    {
        _http = http;
        _authStateProvider = authStateProvider;
        this._localStorage = _localStorage;
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
        await _localStorage.SetItemAsync("_user", request.Email);
        OnChange?.Invoke();
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
        await _localStorage.RemoveItemAsync("_user");
        OnChange?.Invoke();
        return;
    }

}

