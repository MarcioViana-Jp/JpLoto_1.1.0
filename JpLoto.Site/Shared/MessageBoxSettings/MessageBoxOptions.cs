namespace JpLoto.Site.Shared.MessageBoxSettings;

public class MessageBoxOptions
{
    public string? Title { get; set; }
    public string? BodyText { get; set; }
    public string? ButtonAcceptText { get; set; } = "Ok";
    public string? ButtonCancelText { get; set; } = "Cancel";
    public int Action { get; set; } = 0;
    public bool Accepted { get; set; } = false;
    public object Object { get; set; }
}
