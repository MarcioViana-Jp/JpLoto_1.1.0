namespace JpLoto.Application.Dto.Response;

public class LoginResponseData
{
    public bool Success { get; set; }
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = new List<string>();
}
