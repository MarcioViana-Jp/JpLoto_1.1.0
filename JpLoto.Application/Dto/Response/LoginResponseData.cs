namespace JpLoto.Application.Dto.Response;

public class LoginResponseData
{
    public bool Sucesso { get; set; }
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public List<string> Erros { get; set; } = new List<string>();
}
