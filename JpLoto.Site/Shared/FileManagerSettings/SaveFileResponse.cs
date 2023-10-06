namespace JpLoto.Site.Shared.FileManagerSettings;

public class SaveFileResponse
{
    public bool Selected { get; set; }
    public bool AlreadyExists { get; set; }
    public bool NotFound { get; set; }
    public string? FileName { get; set; }
}
