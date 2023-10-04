using JpLoto.Application.Dto;
using System.Net.Http.Json;

namespace JpLoto.Site.Repositories;

public class MiniLResultRepository : IMiniLResultRepository
{
    private readonly HttpClient _http;
    private readonly IAppConfigService _appConfigService;

    public event Action? OnChange;
    public List<MiniLotoResultDto>? Results { get; set; }

    public MiniLResultRepository(HttpClient http, IAppConfigService appConfigService)
    {
        _http = http;
        _appConfigService = appConfigService;
    }
    public async Task<object> AddAsync(MiniLotoResultDto request)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var result = await _http.PostAsJsonAsync($"{appConfig.CorsSetting.ApiHost}/api/minilotoresults", request);
        var response = await result.Content.ReadFromJsonAsync<int>();
        OnChange?.Invoke();
        _ = await GetAllAsync();
        return response;
    }

    public async Task<IEnumerable<MiniLotoResultDto>> GetAllAsync()
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var results = await _http.GetFromJsonAsync<IEnumerable<MiniLotoResultDto>>($"{appConfig.CorsSetting.ApiHost}/api/minilotoresults");
        Results = results.ToList();
        //OnChange?.Invoke();
        return Results;
    }

    public async Task<MiniLotoResultDto?> GetByIdAsync(int id)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var response = await _http.GetFromJsonAsync<MiniLotoResultDto>($"{appConfig.CorsSetting.ApiHost}/api/minilotoresults/getbyid/{id}");
        OnChange?.Invoke();
        return response;
    }

    public async Task RemoveByIdAsync(int id)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var response = await _http.DeleteAsync($"{appConfig.CorsSetting.ApiHost}/api/minilotoresults/{id}");
        _ = await GetAllAsync();
        OnChange?.Invoke();
    }

    public async Task UpdateAsync(MiniLotoResultDto request)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var response = await _http.PutAsJsonAsync($"{appConfig.CorsSetting.ApiHost}/api/minilotoresults/update", request);
        _ = await GetAllAsync();
        OnChange?.Invoke();
    }

    public MiniLotoResultDto CreateNewResult()
    {
        MiniLotoResultDto result = new MiniLotoResultDto { IsNew = true, Editing = true };
        Results.Add(result);
        OnChange.Invoke();
        return result;
    }
}
