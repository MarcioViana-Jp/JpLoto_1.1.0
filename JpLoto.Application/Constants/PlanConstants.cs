namespace JpLoto.Application.Constants;

public static class PlanExpiration
{
    // Constants for 'ExpirationDescriptor'
    public const int ExpiresInDays = 0;
    public const int ExpiresInMonths = 1;
    public const int ExpiresInYears = 2;
    public static readonly string[] Descriptors = { "ExpiresInDays", "ExpiresInMonths", "ExpiresInYears" };    
}
