using JpLoto.Globalization.Localization.Constants;

namespace JpLoto.Site.Dto;

public class PrintConfigDto
{
    public string TamanhoPapel { get; set; } = PrintConfigDefaults.TamanhoPapel;
    public int PapelMargemCabecalho { get; set; } = PrintConfigDefaults.PapelMargemCabecalho;
    public int PapelMargemSuperior { get; set; } = PrintConfigDefaults.PapelMargemSuperior;
    public int PapelMargemEsquerda { get; set; } = PrintConfigDefaults.PapelMargemEsquerda;
    public int CartelaMargemCabecalho { get; set; } = PrintConfigDefaults.CartelaMargemCabecalho;
    public int CartelaMargemSuperior { get; set; } = PrintConfigDefaults.CartelaMargemSuperior;
    public int CartelaMargemEsquerda { get; set; } = PrintConfigDefaults.CartelaMargemEsquerda;
    public int LarguraCartela { get; set; } = PrintConfigDefaults.LarguraCartela;
    public int AlturaCartela { get; set; } = PrintConfigDefaults.AlturaCartela;
}
