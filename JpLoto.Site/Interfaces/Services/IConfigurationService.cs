namespace JpLoto.Site.Interfaces.Services
{
    public interface IConfigurationService
    {
        Task<AppConfigDto> GetConfiguration();
        Task<PrintConfigDto> GetPrintConfiguration();
        Task<FiltersDto> GetLotoFilters(int lotoType);
        Task<FiltersDto> GetMiniLotoFilters();
        Task<FiltersDto> GetLoto6Filters();
        Task<FiltersDto> GetLoto7Filters();
        Task SaveConfiguration(AppConfigDto appConfig);
        Task SavePrintConfiguration(PrintConfigDto appConfig);
        Task SaveLotoFilters(int lotoType, FiltersDto filterDto);
        Task SaveMiniLotoFilters(FiltersDto filterDto);
        Task SaveLoto6Filters(FiltersDto filterDto);
        Task SaveLoto7Filters(FiltersDto filterDto);
    }
}
