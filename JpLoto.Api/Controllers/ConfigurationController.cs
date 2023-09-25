using Microsoft.AspNetCore.Authorization;
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
    
    
    [HttpGet]
    public IActionResult LoadAppConfiguration()
    {
        var retorno = JsonConvert.SerializeObject(_appConfig.LoadAppConfiguration());
        return Ok(retorno);
    }
    
}
