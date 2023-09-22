using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace JpLoto.Api.Controllers;

[Route("[controller]/[action]")]
[AllowAnonymous]
public class CultureController : Controller
{
    //[HttpGet("set/{culture}/{redirectUri}")]
    [HttpGet]
    public IActionResult Set(string culture, string redirectUri)
    {
        if (!string.IsNullOrEmpty(culture))
        {
            HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(culture, culture)));
        }
        return Redirect(redirectUri);
    }

    [HttpGet("{culture}")]
    public IActionResult SetServerCulture(string culture)
    {
        if (string.IsNullOrEmpty(culture))
            culture = new CultureInfo(LocalizationSettings.DefaultCultureCode).Name;
        HttpContext.Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(
                new RequestCulture(culture, culture)));
        return Ok();
    }
}
