using JpLoto.Api.Extensions;
using JpLoto.Application.DTOs.Request;
using JpLoto.Application.DTOs.Response;
using JpLoto.Application.Interfaces.Services;
using JpLoto.EmailServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace JpLoto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private IIdentityService _identityService;
    private readonly IEmailService _emailService;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(IIdentityService identityService, IEmailService emailService, UserManager<IdentityUser> userManager)
    {
        _identityService = identityService;
        _emailService = emailService;
        _userManager = userManager;
    }

    [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var resultado = await _identityService.RegisterNewUser(registerRequest);
        if (resultado.Sucesso)
        {
            var user = await _userManager.FindByEmailAsync(registerRequest.Email);
            if(user == null)
            {
                resultado.AdicionarErro("Usuario adicionado, mas nao foi possivel enviar o e-mail de confirmacao.");
                return Ok(resultado);
            }

            var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action(action: "confirmemail", controller: "Account",
                                   values: new {userId = user.Id, token = confirmationToken},
                                   protocol: "https", host: "localhost:7125") ?? "/";

            string msgBody = $"Clique no link abaixo para confirmar seu endereço de e-mail: \n\n {confirmationLink}";

            await _emailService.SendAsync(registerRequest.Email, "Confirme seu e-mail.", msgBody);

            return Ok(resultado);
        }
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

    [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("logout")]
    public async Task<ActionResult<RegisterResponse>> Logout()
    {
        await _identityService.Logout();
        
        return Ok("Usuários desconectado com sucesso!");
    }
    
    [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("confirmemail")]
    public async Task<ActionResult<RegisterResponse>> ConfirmEmail(string userId, string token)
    {     
        return Ok("Usuários criado e e-mail enviado com sucesso!");
    }

}

