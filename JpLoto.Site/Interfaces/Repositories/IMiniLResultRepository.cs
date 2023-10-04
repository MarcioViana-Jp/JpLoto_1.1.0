using JpLoto.Application.Dto;

namespace JpLoto.Site.Interfaces.Repositories;

public interface IMiniLResultRepository
{
    event Action? OnChange;
    List<MiniLotoResultDto>? Results { get; set; }
    Task<IEnumerable<MiniLotoResultDto>> GetAllAsync();
    Task<MiniLotoResultDto?> GetByIdAsync(int id);
    Task<object> AddAsync(MiniLotoResultDto request);
    Task UpdateAsync(MiniLotoResultDto request);
    Task RemoveByIdAsync(int id); 
    MiniLotoResultDto CreateNewResult();
}
