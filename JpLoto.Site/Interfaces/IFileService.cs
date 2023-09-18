using JpLoto.Lottery.Dto;

namespace JpLoto.Site.Interfaces;

public interface IFileService
{
    Task<bool> SaveFileAsync(LotoFile lotoFile, string file);
    Task<LotoFile?> ReadFileAsync(IBrowserFile file);
}
