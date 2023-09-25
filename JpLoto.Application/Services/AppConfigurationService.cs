using JpLoto.Application.Interfaces;
using JpLoto.Application.Settings;
using Microsoft.Extensions.Options;

namespace JpLoto.Application.Services;

public class AppConfigurationService : IAppConfigurationService
{
    private readonly IOptions<AppSetting> _appSetting;
    //private readonly IOptions<PrinterSetting> _printer;
    private readonly IOptions<CorsSetting> _corsSetting;
    private readonly IOptions<SmtpSetting> _smtp;

    //public AppConfigurationService(IOptions<AppSetting> app, IOptions<PrinterSetting> printer, IOptions<CorsSetting> cors, IOptions<SmtpSetting> smtp)
    public AppConfigurationService(IOptions<AppSetting> app, IOptions<CorsSetting> cors, IOptions<SmtpSetting> smtp)
    {
        _appSetting = app;
        //_printer = printer;
        _corsSetting = cors;
        _smtp = smtp;
    }

    public AppConfiguration LoadAppConfiguration()
    {
        //var appConfig = new AppConfiguration(_appSetting.Value, _printer.Value, _corsSetting.Value, _smtp.Value);
        var appConfig = new AppConfiguration(_appSetting.Value, _corsSetting.Value, _smtp.Value);
        return appConfig;
    }

}
