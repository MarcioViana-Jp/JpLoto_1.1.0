using System.Globalization;

namespace JpLoto.Globalization.Localization.Constants;

public class LocalizationSettings
{
    public static string[] SupportedCulturesCodes
    {
        get => new string[] { "ja-JP", "pt-BR", "en-US", "es-ES" };
    }
    public static List<CultureInfo> SupportedCultures
    {
        get => new List<CultureInfo>
        {
            new CultureInfo(SupportedCulturesCodes[0]),
            new CultureInfo(SupportedCulturesCodes[1]),
            new CultureInfo(SupportedCulturesCodes[2]),
            new CultureInfo(SupportedCulturesCodes[3]),
        };
    }
    public static string DefaultCultureCode
    {
        get => SupportedCulturesCodes[0];
    }
    public static CultureInfo DefaultCulture
    {
        get => SupportedCultures[0];
    }
}
