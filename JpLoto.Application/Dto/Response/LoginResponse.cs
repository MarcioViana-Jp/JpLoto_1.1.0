using System.Text.Json.Serialization;

namespace JpLoto.Application.Dto.Response;

public class LoginResponse
{
    public bool Success  => Errors.Count == 0;
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string AccessToken { get; private set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string RefreshToken { get; private set; }
    
    public List<string> Errors { get; private set; }

    public LoginResponse() =>
        Errors = new List<string>();

    public LoginResponse(bool success, string accessToken, string refreshToken) : this()
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

    public void AddError(string error) =>
        Errors.Add(error);

    public void AddErrors(IEnumerable<string> errors) =>
        Errors.AddRange(errors);
}