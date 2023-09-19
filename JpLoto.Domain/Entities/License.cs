using JpLoto.Domain.Entities.Shared;

namespace JpLoto.Domain.Entities;

public class License : Entity
{
    public string? UserId { get; set; } = string.Empty;
    public string? PlanCode { get; set; } = string.Empty;
    public DateTime SubscriptionDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Price { get; set; } = 0;
    public bool IsActive { get; set; } = true;

}