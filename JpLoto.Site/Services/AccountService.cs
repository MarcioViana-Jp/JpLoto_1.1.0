using JpLoto.Application.Dto.Request;
using JpLoto.Application.Dto.Response;
using JpLoto.Application.Settings;
using JpLoto.Site.Interfaces.Services;
using System.Net.Http.Json;

namespace JpLoto.Site.Services;

public class AccountService : IAccountService
{
    public event Action? OnChange;
    private readonly HttpClient _http;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly ILocalStorageService _localStorage;
    private readonly CorsSetting _corsSetting;

    public AccountService(HttpClient http,
                          AuthenticationStateProvider authStateProvider,
                          ILocalStorageService localStorage)
    {
        _http = http;
        _authStateProvider = authStateProvider;
        _localStorage = localStorage;

        // TODO - Aguardando implementacao da controller AppConfiguration
        bool _isProductionMode = false;
        if (_isProductionMode)
        {
            _corsSetting = new CorsSetting()
            {
                ApiHost = "apiv1-1.jploto.com",
                AllowedOrigins = "v1-1.jploto.com"
            };
        }
        else
        {
            _corsSetting = new CorsSetting()
            {
                ApiHost = "https://localhost:7125",
                AllowedOrigins = "https://localhost:7219"
            };
        }
    }

    public async Task<RegisterResponseData> ChangePassword(ChangePasswordRequest request)
    {
        var result = await _http.PostAsJsonAsync($"{_corsSetting.ApiHost}/api/account/changepassword", request);
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
        var result = await _http.PostAsJsonAsync($"{_corsSetting.ApiHost}/api/account/login", request);
        await _localStorage.SetItemAsync("_user", request.Email);
        OnChange?.Invoke();
        return await result.Content.ReadFromJsonAsync<LoginResponseData>();
    }

    public async Task<RegisterResponseData> Register(RegisterRequest request)
    {
        var result = await _http.PostAsJsonAsync($"{_corsSetting.ApiHost}/api/account/register", request);
        return await result.Content.ReadFromJsonAsync<RegisterResponseData>();
    }

    public async Task<bool> ResendConfirmationEmail(EmailRequest request)
    {
        await _http.PostAsJsonAsync($"{_corsSetting.ApiHost}/api/account/resendemail", request);
        return true;
    }

    public async Task Logout()
    {
        await _http.GetAsync($"{_corsSetting.ApiHost}/api/account/logout");
        await _localStorage.RemoveItemAsync("_user");
        OnChange?.Invoke();
        return;
    }

    public async Task<string> GetCurrentUserName()
    {
        return await _localStorage.GetItemAsStringAsync("_user");
    }
}

