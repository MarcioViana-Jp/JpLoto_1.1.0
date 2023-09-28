using JpLoto.Application.Dto.Request;
using JpLoto.Application.Dto.Response;
using System.Net.Http.Json;

namespace JpLoto.Site.Services;

public class AccountService : IAccountService
{
    public event Action? OnChange;
    private readonly HttpClient _http;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly ILocalStorageService _localStorage;
    private readonly IAppConfigService _appConfigService;

    public AccountService(HttpClient http,
                          AuthenticationStateProvider authStateProvider,
                          ILocalStorageService localStorage,
                          IAppConfigService appConfigService)
    {
        _http = http;
        _authStateProvider = authStateProvider;
        _localStorage = localStorage;
        _appConfigService = appConfigService;
    }

    public async Task<RegisterResponseData> ChangePassword(ChangePasswordRequest request)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var result = await _http.PostAsJsonAsync($"{appConfig.CorsSetting.ApiHost}/api/account/changepassword", request);
        var response = await result.Content.ReadFromJsonAsync<RegisterResponseData>();
        return response;
    }

    public async Task<bool> IsUserAuthenticated()
    {
        bool isAuthenticated = (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        OnChange?.Invoke();
        return isAuthenticated;
    }

    public async Task<LoginResponseData> Login(LoginRequest request)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var result = await _http.PostAsJsonAsync($"{appConfig.CorsSetting.ApiHost}/api/account/login", request);
        await _localStorage.SetItemAsync("_user", request.Email);
        OnChange?.Invoke();
        return await result.Content.ReadFromJsonAsync<LoginResponseData>();
    }

    public async Task<RegisterResponseData> Register(RegisterRequest request)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var result = await _http.PostAsJsonAsync($"{appConfig.CorsSetting.ApiHost}/api/account/register", request);
        return await result.Content.ReadFromJsonAsync<RegisterResponseData>();
    }

    public async Task<bool> ResendConfirmationEmail(EmailRequest request)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        await _http.PostAsJsonAsync($"{appConfig.CorsSetting.ApiHost}/api/account/resendemail", request);
        return true;
    }

    public async Task Logout()
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        await _http.GetAsync($"{appConfig.CorsSetting.ApiHost}/api/account/logout");
        await _localStorage.RemoveItemAsync("_user");
        await _appConfigService.RemoveAppCookieAsync();
        OnChange?.Invoke();
        return;
    }

    public async Task<string> GetCurrentUserName()
    {
        var email = (await _localStorage.GetItemAsStringAsync("_user")).Replace("\"", "") ?? "* Not authenticaded *";
        return email;
        //return await _localStorage.GetItemAsStringAsync("_user") ?? "* Not authenticaded *";
    }

    public async Task<string> GetUserIdByEmailAsync(string email)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        return await _http.GetStringAsync($"{appConfig.CorsSetting.ApiHost}/api/account/getuseridbyemail/{email}");
    }
}

