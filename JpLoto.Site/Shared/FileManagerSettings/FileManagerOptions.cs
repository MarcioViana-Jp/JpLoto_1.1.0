﻿namespace JpLoto.Site.Shared.FileManagerSettings;

public class FileManagerOptions
{
    public string? Title { get; set; }
    public string? SuggestedFileName { get; set; }
    public string? FileDescription { get; set; }
    public string? FileExtension { get; set; }
    public string? ButtonOpenText { get; set; } = "Open";
    public string? ButtonSaveText { get; set; } = "Save";
    public string? ButtonCancelText { get; set; } = "Cancel";
    public bool Selected { get; set; } = false;
}
