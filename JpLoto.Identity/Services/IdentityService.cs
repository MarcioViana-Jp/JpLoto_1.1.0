using JpLoto.Application.Dto.Request;
using JpLoto.Application.Dto.Response;
using JpLoto.Application.Interfaces.Services;
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

        public async Task<RegisterResponseApplication> RegisterNewUser(RegisterRequestApplication usuarioCadastro)
        {
            var identityUser = new IdentityUser
            {
                UserName = usuarioCadastro.Email,
                Email = usuarioCadastro.Email,
                EmailConfirmed = false,             // User can do it by checking the 'Email confirmation link' sent on Register
                TwoFactorEnabled = false            // User can do it on 'UserProfile/SecuritySettings'
            };

            var result = await _userManager.CreateAsync(identityUser, usuarioCadastro.Senha);
            if (result.Succeeded)
                await _userManager.SetLockoutEnabledAsync(identityUser, false);

            var usuarioCadastroResponse = new RegisterResponseApplication(result.Succeeded);
            if (!result.Succeeded && result.Errors.Count() > 0)
                usuarioCadastroResponse.AdicionarErros(result.Errors.Select(r => r.Description));

            return usuarioCadastroResponse;
        }
        
        public async Task<RegisterResponseApplication> ChangePassword(ChangePasswordRequestApplication changePswRequest)
        {
            var response = new RegisterResponseApplication(true);
            var identityUser = await _userManager.FindByEmailAsync(changePswRequest.UserName); // TODO - Para ajustar depois
            var result = await _userManager.ChangePasswordAsync(identityUser, changePswRequest.SenhaAtual, changePswRequest.NovaSenha);

            if (result.Succeeded)
                await _userManager.SetLockoutEnabledAsync(identityUser, false);
            else if (!result.Succeeded && result.Errors.Count() > 0)
                response.AdicionarErros(result.Errors.Select(r => r.Description));

            return response;
        }

        public async Task<LoginResponseApplication> Login(LoginRequestApplication usuarioLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, usuarioLogin.IsPersistent, true);
            if (result.Succeeded)
                return await GenerateCredentials(usuarioLogin.Email);

            var usuarioLoginResponse = new LoginResponseApplication();
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    usuarioLoginResponse.AdicionarErro("Essa conta está bloqueada");
                else if (result.IsNotAllowed)
                    usuarioLoginResponse.AdicionarErro("Essa conta não tem permissão para fazer login");
                else if (result.RequiresTwoFactor)
                    usuarioLoginResponse.AdicionarErro("É necessário confirmar o login no seu segundo fator de autenticação");
                else
                    usuarioLoginResponse.AdicionarErro("Usuário e/ou senha estão incorretos");
            }

            return usuarioLoginResponse;
        }

        public async Task Logout()
        {
            // Logoff direto, sem confirmacao
            await _signInManager.SignOutAsync();
        }

        public async Task<LoginResponseApplication> RefreshToken(string usuarioId)
        {
            var usuarioLoginResponse = new LoginResponseApplication();
            var usuario = await _userManager.FindByIdAsync(usuarioId);

            if (await _userManager.IsLockedOutAsync(usuario))
                usuarioLoginResponse.AdicionarErro("Essa conta está bloqueada");
            else if (!await _userManager.IsEmailConfirmedAsync(usuario))
                usuarioLoginResponse.AdicionarErro("Essa conta precisa confirmar seu e-mail antes de realizar o login");

            if (usuarioLoginResponse.Sucesso)
                return await GenerateCredentials(usuario.Email);

            return usuarioLoginResponse;
        }

        private async Task<LoginResponseApplication> GenerateCredentials(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var accessTokenClaims = await TakeClaims(user, adicionarClaimsUsuario: true);
            var refreshTokenClaims = await TakeClaims(user, adicionarClaimsUsuario: false);

            var dataExpiracaoAccessToken = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
            var dataExpiracaoRefreshToken = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenExpiration);

            var accessToken = GerarToken(accessTokenClaims, dataExpiracaoAccessToken);
            var refreshToken = GerarToken(refreshTokenClaims, dataExpiracaoRefreshToken);

            return new LoginResponseApplication
            (
                sucesso: true,
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