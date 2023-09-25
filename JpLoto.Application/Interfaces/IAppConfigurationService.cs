using JpLoto.Application.Settings;

namespace JpLoto.Application.Interfaces;

public interface IAppConfigurationService
{
    AppConfiguration LoadAppConfiguration();
}
