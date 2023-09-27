using JpLoto.Application.Dto.Request;
using JpLoto.Application.Dto.Response;
using JpLoto.Application.Settings;
using JpLoto.Domain.Entities;
using System.Net.Http.Json;

namespace JpLoto.Site.Repositories;

public class MyProfileRepository : IMyProfileRepository
{
    private readonly HttpClient _http;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly ILocalStorageService _localStorage;
    private readonly IAppConfigService _appConfigService;
    private readonly CorsSetting _corsSetting;

    public event Action? OnChange;

    public MyProfileRepository(HttpClient http, AuthenticationStateProvider authStateProvider,
                                       ILocalStorageService localStorage,
                                       IAppConfigService appConfigService)
    {
        _http = http;
        _authStateProvider = authStateProvider;
        _localStorage = localStorage;
        _appConfigService = appConfigService;
    }

    public async Task<object> AddAsync(UserDetailAddRequest request)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var result = await _http.PostAsJsonAsync($"{appConfig.CorsSetting.ApiHost}/api/userdetails/add", request);
        var response = await result.Content.ReadFromJsonAsync<int>();
        OnChange?.Invoke();
        return response;
    }

    public void Dispose()
    {
        // TODO - Not implemented 
    }

    public async Task<IEnumerable<UserDetailResponse>> GetAllAsync()
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var response = await _http.GetFromJsonAsync<IEnumerable<UserDetailResponse>>($"{appConfig.CorsSetting.ApiHost}/api/userdetails/getall");
        OnChange?.Invoke();
        return response;
    }

    public async Task<UserDetailResponse?> GetByIdAsync(int id)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var response = await _http.GetFromJsonAsync<UserDetailResponse>($"{appConfig.CorsSetting.ApiHost}/api/userdetails/getbyid/{id}");
        OnChange?.Invoke();
        return response;
    }

    public async Task<UserDetailResponse> GetByUserIdAsync(string userId)
    {
        var response = new UserDetailResponse();
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        try
        {
            response = await _http.GetFromJsonAsync<UserDetailResponse>($"{appConfig.CorsSetting.ApiHost}/api/userdetails/getbyuserid/{userId}");
        }
        catch
        {
            response = new();
        }
        OnChange?.Invoke();
        return response;
    }

    public async Task RemoveAsync(UserDetail userDetail)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var response = await _http.DeleteAsync($"{appConfig.CorsSetting.ApiHost}/api/userdetails/remove/{userDetail}");
        OnChange?.Invoke();
    }

    public async Task RemoveByIdAsync(int id)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var response = await _http.DeleteAsync($"{appConfig.CorsSetting.ApiHost}/api/userdetails/removebyid/{id}");
        OnChange?.Invoke();
    }

    public async Task UpdateAsync(UserDetailUpdateRequest request)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var response = await _http.PutAsJsonAsync($"{appConfig.CorsSetting.ApiHost}/api/userdetails/update", request);
        OnChange?.Invoke();
    }
}
