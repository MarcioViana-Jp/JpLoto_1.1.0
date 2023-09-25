using JpLoto.Application.Settings;

namespace JpLoto.Site.Interfaces.Services;

public interface IAppConfigService
{
    Task<AppConfiguration> LoadAppConfigurationAsync();
    Task<AppConfiguration> GetAppConfigurationAsync();
    Task RemoveAppCookieAsync();
}
