using JpLoto.Application.Settings;
using JpLoto.Domain.Entities;
using System.Net.Http.Json;

namespace JpLoto.Site.Repositories;

public class AccountUserDetailRepository : IAccountUserDetailRepository
{
    private readonly HttpClient _http;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly ILocalStorageService _localStorage;
    private readonly IAppConfigService _appConfigService;
    private readonly CorsSetting _corsSetting;

    public event Action? OnChange;

    public AccountUserDetailRepository(HttpClient http, AuthenticationStateProvider authStateProvider,
                                       ILocalStorageService localStorage,
                                       IAppConfigService appConfigService)
    {
        _http = http;
        _authStateProvider = authStateProvider;
        _localStorage = localStorage;
        _appConfigService = appConfigService;
    }

    public async Task<object> AddAsync(JplUserDetail request)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var result = await _http.PostAsJsonAsync($"{appConfig.CorsSetting.ApiHost}/api/userdetails/add", request);
        var response = await result.Content.ReadFromJsonAsync<JplUserDetail>();
        OnChange?.Invoke();
        return response;
    }

    public void Dispose()
    {
        // TODO - Not implemented 
    }

    public async Task<IEnumerable<JplUserDetail>> GetAllAsync()
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var response = await _http.GetFromJsonAsync<IEnumerable<JplUserDetail>>($"{appConfig.CorsSetting.ApiHost}/api/userdetails/getall");
        OnChange?.Invoke();
        return response;
    }

    public async Task<JplUserDetail?> GetByIdAsync(int id)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var response = await _http.GetFromJsonAsync<JplUserDetail>($"{appConfig.CorsSetting.ApiHost}/api/userdetails/getbyid/{id}");
        OnChange?.Invoke();
        return response;
    }

    public async Task<JplUserDetail> GetByUserIdAsync(string userId)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var response = await _http.GetFromJsonAsync<JplUserDetail>($"{appConfig.CorsSetting.ApiHost}/api/userdetails/getbyuserid/{userId}");
        OnChange?.Invoke();
        return response;
    }

    public async Task RemoveAsync(JplUserDetail userDetail)
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

    public async Task UpdateAsync(JplUserDetail request)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var response = await _http.PutAsJsonAsync($"{appConfig.CorsSetting.ApiHost}/api/userdetails/removebyid", request);
        OnChange?.Invoke();
    }
}
