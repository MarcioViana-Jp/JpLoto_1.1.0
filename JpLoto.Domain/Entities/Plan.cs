using JpLoto.Domain.Entities.Shared;

namespace JpLoto.Domain.Entities;

public class Plan : Entity
{
    public string? PlanCode { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public int Price { get; set; } = 0;
    public DateTime NotBefore { get; set; }
    public DateTime ValidTrhu { get; set; }
    public int ExpirationFactor { get; set; } = 0; // it willl be added to the current date to determine licence expiration
    public int ExpirationDescriptor { get; set; } = 0; // 0-day, 1-month, 2-year
    public bool IsActive { get; set; } = true;

}