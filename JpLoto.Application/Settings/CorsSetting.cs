namespace JpLoto.Application.Settings;

[Serializable]
public class CorsSetting
{
    public string ApiHost { get; set; } = string.Empty;
    public string AllowedOrigins { get; set; } = string.Empty;
}
