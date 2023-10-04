using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace JpLoto.Api.Controllers;

[Route("[controller]/[action]")]
[AllowAnonymous]

public class CulturesController : Controller
{
    [EnableCors("cors_policy")]
    [HttpGet]
    public IActionResult Set([FromQuery] string culture, [FromQuery] string redirectUrl)
    {
        if (!string.IsNullOrEmpty(culture))
        {
            SetServerCulture(culture);
        }
        return Redirect(redirectUrl);
    }


    [EnableCors("cors_policy")]
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
