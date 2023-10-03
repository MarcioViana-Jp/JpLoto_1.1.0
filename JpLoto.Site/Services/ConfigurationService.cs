using JpLoto.Lottery.Constants;

namespace JpLoto.Site.Services;

public class ConfigurationService : IConfigurationService
{
    private readonly ILocalStorageService _localStorage;
    public ConfigurationService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<AppConfigDto> GetConfiguration()
    {
        var config = await _localStorage.GetItemAsync<AppConfigDto>("appConfig");
        if (config == null)
            return new AppConfigDto();
        else
            return config;
    }

    public async Task<PrintConfigDto> GetPrintConfiguration()
    {
        var config = await GetConfiguration();
        return config.PrintConfig;
    }

    public async Task<FiltersDto> GetLoto6Filters()
    {
        var config = await GetConfiguration();
        return config.Loto6Filters;
    }

    public async Task<FiltersDto> GetLoto7Filters()
    {
        var config = await GetConfiguration();
        return config.Loto7Filters;
    }

    public async Task<FiltersDto> GetMiniLotoFilters()
    {
        var config = await GetConfiguration();
        return config.MiniLotoFilters;
    }

    public async Task SaveConfiguration(AppConfigDto appConfig)
    {
        await _localStorage.SetItemAsync<AppConfigDto>("appConfig", appConfig);
    }

    public async Task SavePrintConfiguration(PrintConfigDto printConfig)
    {
        var config = await GetConfiguration();
        config.PrintConfig = printConfig;
        await SaveConfiguration(config);
    }

    public async Task SaveLoto6Filters(FiltersDto filterDto)
    {
        var config = await GetConfiguration();
        config.Loto6Filters = filterDto;
        await SaveConfiguration(config);
    }

    public async Task SaveLoto7Filters(FiltersDto filterDto)
    {
        var config = await GetConfiguration();
        config.Loto7Filters = filterDto;
        await SaveConfiguration(config);
    }

    public async Task SaveMiniLotoFilters(FiltersDto filterDto)
    {
        var config = await GetConfiguration();
        config.MiniLotoFilters = filterDto;
        await SaveConfiguration(config);
    }

    public async Task<FiltersDto> GetLotoFilters(int lotoType)
    {
        switch (lotoType)
        {
            case LotoType.MiniLoto:
                return await GetMiniLotoFilters();
            case LotoType.Loto6:
                return await GetLoto6Filters();
            case LotoType.Loto7:
                return await GetLoto7Filters();
            default:
                return new FiltersDto();
        }
    }

    public async Task SaveLotoFilters(int lotoType, FiltersDto filterDto)
    {
        switch (lotoType)
        {
            case LotoType.MiniLoto:
                await SaveMiniLotoFilters(filterDto);
                break;
            case LotoType.Loto6:
                await SaveLoto6Filters(filterDto);
                break;
            case LotoType.Loto7:
                await SaveLoto7Filters(filterDto);
                break;

        }
    }
}
