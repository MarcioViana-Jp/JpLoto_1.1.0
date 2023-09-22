using JpLoto.Application.Interfaces.Services;
using JpLoto.Application.Settings;
using Microsoft.Extensions.Options;

namespace JpLoto.Application.Services;

public class CorsSettingService : ICorsSettingService
{
    private readonly IOptions<CorsSetting> _corsSetting;

    public CorsSettingService(IOptions<CorsSetting> corsSetting)
    {
        _corsSetting = corsSetting;
    }
    public string GetAllowedOrigins()
    {
        return _corsSetting.Value.AllowedOrigins;
    }

    public string GetApiHosting()
    {
        return _corsSetting.Value.ApiHost;
    }
}
