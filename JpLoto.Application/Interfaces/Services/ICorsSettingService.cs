namespace JpLoto.Application.Interfaces.Services;

public interface ICorsSettingService
{
    string GetApiHosting();
    string GetAllowedOrigins();
}
