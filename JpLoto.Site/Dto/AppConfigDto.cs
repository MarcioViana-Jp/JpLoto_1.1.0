namespace JpLoto.Site.Dto;

public class AppConfigDto
{
    public PrintConfigDto PrintConfig { get; set; } = new();
    public FiltersDto MiniLotoFilters { get; set; } = new();
    public FiltersDto Loto6Filters { get; set; } = new();
    public FiltersDto Loto7Filters { get; set; } = new();
}
