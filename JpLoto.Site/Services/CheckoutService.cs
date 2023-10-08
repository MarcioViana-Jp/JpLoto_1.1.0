using JpLoto.Application.Dto.Request;
using System.Net.Http.Json;

namespace JpLoto.Site.Services;

public class CheckoutService : ICheckoutService
{
    private readonly HttpClient _http;
    private readonly IAppConfigService _appConfigService;

    public CheckoutService(HttpClient http, IAppConfigService appConfigService)
    {
        _http = http;
        _appConfigService = appConfigService;
    }

    public async Task<string> PlaceOrder(CheckoutRequest request)
    {
        var appConfig = await _appConfigService.GetAppConfigurationAsync();
        var result = await _http.PostAsJsonAsync($"{appConfig.CorsSetting.ApiHost}/api/payment/checkout", request);
        var url = await result.Content.ReadAsStringAsync();
        return url;
    }
}
