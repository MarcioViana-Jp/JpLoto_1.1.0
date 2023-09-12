namespace JPLoto.Domain.Dto.Response;

public class RegisterResponse
{
    public bool Success { get => Errors.Count == 0; }
    public int ErrorCode { get; set; } = 0;
    public List<string> Errors { get; set; } = new();

    public void AddError(string error) =>
        Errors.Add(error);

    public void AddErrors(IEnumerable<string> errors) =>
        Errors.AddRange(errors);
}
