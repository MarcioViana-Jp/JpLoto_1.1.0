using JpLoto.Lottery.Dto;

namespace JpLoto.Lottery.Shared;

public class LotoResponse
{
    public bool Successo { get; set; } = true;
    public string Mensagem { get; set; } = string.Empty;
    public List<Jogo> Combinacoes { get; set; } = new();
}
