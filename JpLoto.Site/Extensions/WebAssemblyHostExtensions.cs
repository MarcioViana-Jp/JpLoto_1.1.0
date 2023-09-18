using JpLoto.Globalization.Localization.Constants;

namespace JpLoto.Site.Extensions
{
    public static class WebAssemblyHostExtensions
    {
        public async static Task SetDefaultCulture(this WebAssemblyHost host)
        {
            var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
            var result = await jsInterop.InvokeAsync<string>("blazorCulture.get");
            CultureInfo culture;
            if (result != null)
                culture = new CultureInfo(result);
            else
            {
                culture = new CultureInfo(LocalizationSettings.DefaultCultureCode);
                await jsInterop.InvokeAsync<string>("blazorCulture.set", LocalizationSettings.DefaultCultureCode);
            }
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}
