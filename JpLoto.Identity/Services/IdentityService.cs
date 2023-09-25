using JpLoto.Application.Dto.Request;
using JpLoto.Application.Dto.Response;
using JpLoto.Application.Interfaces;
using JpLoto.Identity.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JpLoto.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtOptions _jwtOptions;

        public IdentityService(SignInManager<IdentityUser> signInManager,
                               UserManager<IdentityUser> userManager,
                               IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<RegisterResponse> RegisterNewUser(RegisterRequest usuarioCadastro)
        {
            var identityUser = new IdentityUser
            {
                UserName = usuarioCadastro.Email,
                Email = usuarioCadastro.Email,
                EmailConfirmed = false,             // User can do it by checking the 'Email confirmation link' sent on Register
                TwoFactorEnabled = false            // User can do it on 'UserProfile/SecuritySettings'
            };

            var result = await _userManager.CreateAsync(identityUser, usuarioCadastro.Password);
            if (result.Succeeded)
                await _userManager.SetLockoutEnabledAsync(identityUser, false);

            var usuarioCadastroResponse = new RegisterResponse(result.Succeeded);
            if (!result.Succeeded && result.Errors.Count() > 0)
                usuarioCadastroResponse.AddErrors(result.Errors.Select(r => r.Description));

            return usuarioCadastroResponse;
        }
        
        public async Task<RegisterResponse> ChangePassword(ChangePasswordRequest changePswRequest)
        {
            var response = new RegisterResponse(true);
            var identityUser = await _userManager.FindByEmailAsync(changePswRequest.UserName); // TODO - Para ajustar depois
            var result = await _userManager.ChangePasswordAsync(identityUser, changePswRequest.CurrentPassword, changePswRequest.NewPassword);

            if (result.Succeeded)
                await _userManager.SetLockoutEnabledAsync(identityUser, false);
            else if (!result.Succeeded && result.Errors.Count() > 0)
                response.AddErrors(result.Errors.Select(r => r.Description));

            return response;
        }
        
        public async Task<IdentityUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email); 
        }

        public async Task<LoginResponse> Login(LoginRequest usuarioLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Password, usuarioLogin.IsPersistent, true);
            if (result.Succeeded)
                return await GenerateCredentials(usuarioLogin.Email);

            var usuarioLoginResponse = new LoginResponse();
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    usuarioLoginResponse.AddError("Essa conta está bloqueada");
                else if (result.IsNotAllowed)
                    usuarioLoginResponse.AddError("Essa conta não tem permissão para fazer login");
                else if (result.RequiresTwoFactor)
                    usuarioLoginResponse.AddError("É necessário confirmar o login no seu segundo fator de autenticação");
                else
                    usuarioLoginResponse.AddError("Usuário e/ou Password estão incorretos");
            }

            return usuarioLoginResponse;
        }

        public async Task Logout()
        {
            // Logoff direto, sem confirmacao
            await _signInManager.SignOutAsync();
        }

        public async Task<LoginResponse> RefreshToken(string usuarioId)
        {
            var usuarioLoginResponse = new LoginResponse();
            var usuario = await _userManager.FindByIdAsync(usuarioId);

            if (await _userManager.IsLockedOutAsync(usuario))
                usuarioLoginResponse.AddError("Essa conta está bloqueada");
            else if (!await _userManager.IsEmailConfirmedAsync(usuario))
                usuarioLoginResponse.AddError("Essa conta precisa confirmar seu e-mail antes de realizar o login");

            if (usuarioLoginResponse.Success)
                return await GenerateCredentials(usuario.Email);

            return usuarioLoginResponse;
        }

        private async Task<LoginResponse> GenerateCredentials(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var accessTokenClaims = await TakeClaims(user, adicionarClaimsUsuario: true);
            var refreshTokenClaims = await TakeClaims(user, adicionarClaimsUsuario: false);

            var dataExpiracaoAccessToken = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
            var dataExpiracaoRefreshToken = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenExpiration);

            var accessToken = GerarToken(accessTokenClaims, dataExpiracaoAccessToken);
            var refreshToken = GerarToken(refreshTokenClaims, dataExpiracaoRefreshToken);

            return new LoginResponse
            (
                success: true,
                accessToken: accessToken,
                refreshToken: refreshToken
            );
        }

        private string GerarToken(IEnumerable<Claim> claims, DateTime dataExpiracao)
        {
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: dataExpiracao,
                signingCredentials: _jwtOptions.SigningCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private async Task<IList<Claim>> TakeClaims(IdentityUser user, bool adicionarClaimsUsuario)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Name, user.UserName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            if (adicionarClaimsUsuario)
            {
                var userClaims = await _userManager.GetClaimsAsync(user);
                var roles = await _userManager.GetRolesAsync(user);

                claims.AddRange(userClaims);

                foreach (var role in roles)
                    claims.Add(new Claim("role", role));
            }

            return claims;
        }

    }
}