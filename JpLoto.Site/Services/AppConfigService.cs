using JpLoto.Application.Settings;
using Newtonsoft.Json;

namespace JpLoto.Site.Services;

public class AppConfigService : IAppConfigService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;

    public AppConfigService(HttpClient http, ILocalStorageService localStorage)
    {
        _http = http;
        _localStorage = localStorage;
    }

    // Load all application from server
    public async Task<AppConfiguration> LoadAppConfigurationAsync()
    {
        //var configStr = await _http.GetStringAsync("https://localhost:7125/Configuration/LoadAppConfiguration");
        var configStr = await _http.GetStringAsync("https://apiv1-1.jploto.com/Configuration/LoadAppConfiguration");

        if (!string.IsNullOrEmpty(configStr))
        {
            var config = JsonConvert.DeserializeObject<AppConfiguration>(configStr);
            await _localStorage.SetItemAsync<AppConfiguration>("jpl_settings", config);
            return config;
        }
        return null;
    }

    // Get configuration from cookie
    public async Task<AppConfiguration> GetAppConfigurationAsync()
    {
        var configStr = await _localStorage.GetItemAsStringAsync("jpl_settings");
        if (!string.IsNullOrEmpty(configStr)) 
            return JsonConvert.DeserializeObject<AppConfiguration>(configStr);
        else
            return null;
    }


    // Remove cookie
    public async Task RemoveAppCookieAsync()
    {
        //await _localStorage.RemoveItemAsync("jpl_settings");
        return;
    }

}
