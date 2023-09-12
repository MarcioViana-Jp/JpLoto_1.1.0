using System.Text.Json.Serialization;

namespace JPLoto.Domain.Dto.Response;

public class LoginResponse
{
    public bool Success { get => Errors.Count == 0; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? AccessToken { get; set; } = string.Empty;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? RefreshToken { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = new();
    public int AuthResponseCode { get; set; } = 0;

    public void AddError(string erro) =>
        Errors.Add(erro);

    public void AddErrors(IEnumerable<string> errors) =>
        Errors.AddRange(errors);
}
