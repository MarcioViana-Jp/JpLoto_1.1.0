using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace JpLoto.Api.Controllers;

[Route("[controller]/[action]")]
[AllowAnonymous]

public class ConfigurationController : Controller
{
    private readonly IAppConfigurationService _appConfig;

    public ConfigurationController(IAppConfigurationService appConfig)
    {
        _appConfig = appConfig;
    }

    [EnableCors("cors_policy")]
    [HttpGet]
    public IActionResult LoadAppConfiguration()
    {
        var retorno = JsonConvert.SerializeObject(_appConfig.LoadAppConfiguration());
        return Ok(retorno);
    }

}
