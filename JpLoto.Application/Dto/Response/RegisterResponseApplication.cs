namespace JpLoto.Application.Dto.Response;

public class RegisterResponseApplication
{
    public bool Sucesso { get; private set; }
    public List<string> Erros { get; private set; }

    public RegisterResponseApplication() =>
        Erros = new List<string>();

    public RegisterResponseApplication(bool sucesso = true) : this() =>
        Sucesso = sucesso;

    public void AdicionarErro(string erro) =>
        Erros.Add(erro);

    public void AdicionarErros(IEnumerable<string> erros) =>
        Erros.AddRange(erros);

    public void AlteraStatus(bool novoStatus) =>
        Sucesso = novoStatus;
}