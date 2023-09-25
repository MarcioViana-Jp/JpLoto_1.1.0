using System.Text.Json;

namespace JpLoto.Site.Services;

public class FileService : IDisposable, IFileService
{
    private readonly IJSRuntime _js;
    //private readonly IHttpClientFactory httpClientFactory;

    public FileService(IJSRuntime js)
    {
        _js = js;
    }
    public async Task<LotoFile?> ReadFileAsync(IBrowserFile file)
    {
        LotoFile? lotoFile = new();
        long maxFileSize = long.MaxValue; //1024 * 15;
        try
        {
            var fileContent = new StreamContent(file.OpenReadStream(maxFileSize));
            var content = fileContent.ReadAsStream();
            lotoFile = await JsonSerializer.DeserializeAsync<LotoFile>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        catch
        {
            return null;
        }
        return lotoFile;
    }

    public async Task<bool> SaveFileAsync(LotoFile lotoFile, string file)
    {
        string buffer;
        try
        {
            buffer = JsonSerializer.Serialize(lotoFile);
        }
        catch
        {
            return false;
        }
        await _js.InvokeVoidAsync("SaveFile", file, buffer);
        return true;
    }

    public void Dispose() { }
}
