namespace JpLoto.Api.Extensions;

public static class ApplicationConfig
{
    public static void ApplicationSetup(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppSetting>(configuration.GetSection("AppSettings"));
        services.Configure<SmtpSetting>(configuration.GetSection("SMTP"));
        services.Configure<CorsSetting>(configuration.GetSection("JplCors"));
    }
}