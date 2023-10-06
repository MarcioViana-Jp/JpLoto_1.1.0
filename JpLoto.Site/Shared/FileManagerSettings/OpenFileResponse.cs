namespace JpLoto.Site.Shared.FileManagerSettings;

public class OpenFileResponse
{
    public bool Open { get; set; }
    public bool NotFound { get; set; }
    public IBrowserFile? File { get; set; }
}
