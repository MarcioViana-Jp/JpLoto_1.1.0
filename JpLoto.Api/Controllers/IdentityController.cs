using JpLoto.Api.Extensions;
using JpLoto.Application.DTOs.Request;
using JpLoto.Application.DTOs.Response;
using JpLoto.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace JpLoto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IdentityController : ControllerBase
{
    private IIdentityService _identityService;

    public IdentityController(IIdentityService identityService) =>
        _identityService = identityService;

    [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost("cadastro")]
    public async Task<IActionResult> Register(RegisterRequest usuarioCadastro)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var resultado = await _identityService.RegisterNewUser(usuarioCadastro);
        if (resultado.Sucesso)
            return Ok(resultado);
        else if (resultado.Erros.Count > 0)
        {
            var problemDetails = new CustomProblemDetails(HttpStatusCode.BadRequest, Request, errors: resultado.Erros);
            return BadRequest(problemDetails);
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }


    [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost("login")]
    public async Task<ActionResult<RegisterResponse>> Login(LoginRequest usuarioLogin)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var resultado = await _identityService.Login(usuarioLogin);
        if (resultado.Sucesso)
            return Ok(resultado);

        return Unauthorized();
    }

    [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [Authorize]
    [HttpPost("refresh-login")]
    public async Task<ActionResult<RegisterResponse>> RefreshLogin()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var usuarioId = identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (usuarioId == null)
            return BadRequest();

        var resultado = await _identityService.RefreshToken(usuarioId);
        if (resultado.Sucesso)
            return Ok(resultado);

        return Unauthorized();
    }
}

