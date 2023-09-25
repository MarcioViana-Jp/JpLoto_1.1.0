namespace JpLoto.Application.Settings;

[Serializable]
public class AppSetting
{
    public string CookieName { get; set; } = string.Empty;
    public bool Encripted { get; set; } = false;
}
