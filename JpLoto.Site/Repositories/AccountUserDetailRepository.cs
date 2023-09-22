using JpLoto.Application.Settings;
using JpLoto.Domain.Entities;
using JpLoto.Site.Interfaces.Repositories;
using System.Net.Http.Json;

namespace JpLoto.Site.Repositories;

public class AccountUserDetailRepository : IAccountUserDetailRepository
{
    private readonly HttpClient _http;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly ILocalStorageService _localStorage;
    private readonly CorsSetting _corsSetting;

    public event Action? OnChange;

    public AccountUserDetailRepository(HttpClient http, AuthenticationStateProvider authStateProvider,
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

    public async Task<object> AddAsync(JplUserDetail request)
    {
        var result = await _http.PostAsJsonAsync($"{_corsSetting.ApiHost}/api/userdetails/add", request);
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
        var response = await _http.GetFromJsonAsync<IEnumerable<JplUserDetail>>($"{_corsSetting.ApiHost}/api/userdetails/getall");
        OnChange?.Invoke();
        return response;
    }

    public async Task<JplUserDetail?> GetByIdAsync(int id)
    {
        var response = await _http.GetFromJsonAsync<JplUserDetail>($"{_corsSetting.ApiHost}/api/userdetails/getbyid/{id}");
        OnChange?.Invoke();
        return response;
    }

    public async Task<JplUserDetail> GetByUserIdAsync(string userId)
    {
        var response = await _http.GetFromJsonAsync<JplUserDetail>($"{_corsSetting.ApiHost}/api/userdetails/getbyuserid/{userId}");
        OnChange?.Invoke();
        return response;
    }

    public async Task RemoveAsync(JplUserDetail userDetail)
    {
        var response = await _http.DeleteAsync($"{_corsSetting.ApiHost}/api/userdetails/remove/{userDetail}");
        OnChange?.Invoke();
    }

    public async Task RemoveByIdAsync(int id)
    {
        var response = await _http.DeleteAsync($"{_corsSetting.ApiHost}/api/userdetails/removebyid/{id}");
        OnChange?.Invoke();
    }

    public async Task UpdateAsync(JplUserDetail request)
    {
        var response = await _http.PutAsJsonAsync($"{_corsSetting.ApiHost}/api/userdetails/removebyid", request);
        OnChange?.Invoke();
    }
}
