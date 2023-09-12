using JpLoto.Site.Services.Account;
using JPLoto.Domain.Dto.Request;
using JPLoto.Domain.Dto.Response;
using System.Net.Http.Json;

namespace JpLoto.Site.Services.AccountService
{
    public class AcountService : IAccountService
    {
        private readonly HttpClient _http;
        //private readonly AuthenticationStateProvider _authStateProvider;

        //public AcountService(HttpClient http, AuthenticationStateProvider authStateProvider)
        public AcountService(HttpClient http)
        {
            _http = http;
            //_authStateProvider = authStateProvider;
        }

        public async Task<RegisterResponse> ChangePassword(ChangePasswordRequest request)
        {
            var result = await _http.PostAsJsonAsync("api/account/change-password", request.NovaSenha);
            return await result.Content.ReadFromJsonAsync<RegisterResponse>();
        }

        //public async Task<bool> IsUserAuthenticated()
        public bool IsUserAuthenticated()
        {
            return true;
            //return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var result = await _http.PostAsJsonAsync("api/account/login", request);
            return await result.Content.ReadFromJsonAsync<LoginResponse>();
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/register", request);
            return await result.Content.ReadFromJsonAsync<RegisterResponse>();
        }
    }
}
