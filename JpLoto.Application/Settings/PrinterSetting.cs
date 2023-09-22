namespace JpLoto.Application.Settings;

public class PrinterSetting
{
    public string? TamanhoPapel { get; set; } = string.Empty;
    public int PapelMargemCabecalho { get; set; }
    public int PapelMargemSuperior { get; set; }
    public int PapelMargemEsquerda { get; set; }
    public int CartelaMargemCabecalho { get; set; }
    public int CartelaMargemSuperior { get; set; }
    public int CartelaMargemEsquerda { get; set; }
    public int LarguraCartela { get; set; }
    public int AlturaCartela { get; set; }
}
