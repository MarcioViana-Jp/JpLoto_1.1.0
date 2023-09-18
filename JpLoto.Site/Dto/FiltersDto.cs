namespace JpLoto.Site.Dto;

public class FiltersDto
{
    public FilterState NumerosPrimos { get; set; } = new();
    public FilterState NumerosEmSequencia { get; set; } = new();
    public FilterState NumerosPorLinha { get; set; } = new();
    public FilterState NumerosPorColuna { get; set; } = new();
    public FilterState NumerosPares { get; set; } = new();
    public FilterState NumerosImpares { get; set; } = new();
}

public class FilterState
{
    public bool Ativo { get; set; } = false;
    public int Minimo { get; set; } = 0;
    public int Maximo { get; set; } = 3;
}
