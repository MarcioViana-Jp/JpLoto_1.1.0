namespace JpLoto.Application.Dto.Response;

public class RegisterResponse
{
    public bool Success { get; private set; }
    public List<string> Errors { get; private set; }

    public RegisterResponse() =>
        Errors = new List<string>();

    public RegisterResponse(bool success = true) : this() =>
        Success = success;

    public void AddError(string erro) =>
        Errors.Add(erro);

    public void AddErrors(IEnumerable<string> erros) =>
        Errors.AddRange(erros);

    public void ChangeStatus(bool newStatus) =>
        Success = newStatus;
}