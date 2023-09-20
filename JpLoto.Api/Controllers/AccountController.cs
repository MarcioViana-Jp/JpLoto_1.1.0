using JpLoto.Application.Dto.Request;
using JpLoto.Application.Dto.Response;
using JpLoto.Application.Interfaces.Services;
using JpLoto.Domain.Interfaces.Services;
using JpLoto.EmailServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace JpLoto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private IIdentityService _identityService;
    private readonly IEmailService _emailService;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITrialService _trialService;

    public AccountController(IIdentityService identityService, IEmailService emailService, 
        UserManager<IdentityUser> userManager, ITrialService trialService)
    {
        _identityService = identityService;
        _emailService = emailService;
        _userManager = userManager;
        _trialService = trialService;
    }


    [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var response = await _identityService.RegisterNewUser(registerRequest);
        if (response.Success)
        {
            await SendEmailAsync(registerRequest.Email);

            var user = await _identityService.GetUserByEmailAsync(registerRequest.Email);
            if(user != null)
            {
                var trial = await _trialService.GetByUserIdAsync(user.Id);
                if (trial == null)
                    await _trialService.AddAsync(
                        new Trial (user.Id, DateTime.Now, DateTime.Now.AddDays(31))
                    );
            }

            return Ok(response);

        }
        else if (response.Errors.Count > 0)
        {
            //var problemDetails = new CustomProblemDetails(HttpStatusCode.BadRequest, Request, errors: response.Errors);
            //return BadRequest(problemDetails);
            return BadRequest(response);
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }


    [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost("resendemail")]
    public async Task<IActionResult> ResendConfirmationEmail(EmailRequest emailRequest)
    {
        // Sending errors are not proccessed. Users might procceed resending email again, instead.
        if (!ModelState.IsValid)
            return BadRequest();

        if (await SendEmailAsync(emailRequest.Email))
        {
            return Ok("E-mail de confirmação reenviado com success.");
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }


    [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest usuarioLogin)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var resultado = await _identityService.Login(usuarioLogin);
        if (resultado.Success)
        {
            return Ok(resultado);
        }

        return Unauthorized(resultado);
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
        if (resultado.Success)
            return Ok(resultado);

        return Unauthorized(resultado);
    }


    [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("logout")]
    public async Task<ActionResult> Logout()
    {
        await _identityService.Logout();

        return Ok("Usuário desconectado do servidor com success!");
    }


    [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpGet("confirmemail")]
    public async Task<ActionResult<RegisterResponse>> ConfirmEmail(string userId, string token)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return Ok("Usuário criado e e-mail enviado com success!");
            }
        }

        return BadRequest("Falha ao confirmar e-mail. Solicite o reenvio do e-mail de confirmação.");
    }


    [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost("changepassword")]
    public async Task<IActionResult> ChangePassword(ChangePasswordRequest changePswRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var response = await _identityService.ChangePassword(changePswRequest);
        if (response.Success)
            return Ok(response);
        else if (response.Errors.Count > 0)
        {
            //var problemDetails = new CustomProblemDetails(HttpStatusCode.BadRequest, Request, errors: response.Errors);
            //return BadRequest(problemDetails);
            return BadRequest(response);
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }



    private async Task<bool> SendEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return false;
        }

        var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var confirmationLink = Url.Action(action: "confirmemail", controller: "Account",
                               values: new { userId = user.Id, token = confirmationToken },
                               protocol: "https", host: "localhost:7125") ?? "/";

        string msgBody = $"Clique no link abaixo para confirmar seu endereço de e-mail: \n\n {confirmationLink}";

        await _emailService.SendAsync(email, "Confirme seu e-mail.", msgBody);

        return true;
    }

}

