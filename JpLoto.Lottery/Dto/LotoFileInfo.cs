namespace JpLoto.Lottery.Dto;

public class LotoFileInfo
{
    private readonly int _tipo;
    private readonly string[] _tipos = { "Mini Loto", "Loto6", "Loto7" };
    private readonly string[] _extensao = { ".jpm", ".jp6", ".jp7" };
    private readonly string[] _descricao = { "JP Mini Loto", "JP Loto6", "JP Loto7" };
    public string Nome { get => _tipos[_tipo]; }
    public string Extensao { get => _extensao[_tipo]; }
    public string Descricao { get => _descricao[_tipo]; }
    public string NomeSugerido { get => "Card_001"; }
    public string NomeSugeridoComExtensao { get => "Card" + Extensao; }

    public LotoFileInfo(int tipo)
    {
        _tipo = tipo;
    }
}
