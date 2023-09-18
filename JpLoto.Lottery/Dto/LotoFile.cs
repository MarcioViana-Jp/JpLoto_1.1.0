namespace JpLoto.Lottery.Dto;

public class LotoFile
{
    public string TipoLoto { get; set; } = string.Empty;
    public string DezenasSelecionadas { get; set; } = string.Empty;
    public string DezenasFixas { get; set; } = string.Empty;
    public List<Jogo> Combinacoes { get; set; } = new();
}
