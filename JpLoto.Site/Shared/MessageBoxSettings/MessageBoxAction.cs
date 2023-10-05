namespace JpLoto.Site.Shared.MessageBoxSettings;

public static class MessageBoxAction
{
    // No Action
    public const int NoAction = 0;
    // CRUD Actions
    public const int Include = 1;
    public const int Update = 2;
    public const int Delete = 3;
    public const int DeleteAll = 4;
    // LOTO ActionNames 
    public const int ClearAll = 5;
    public const int DeleteCombination = 6;
    public const int DeleteRecycledCombination = 7;
    // Descriptions
    public static readonly string[] ActionName = {"No action",
        "Include", "Update", "Delete", "Delete all",
        "Clear all", "Delete combination", "Delete recycled combination" };
}
