using JpLoto.Domain.Entities.Shared;

namespace JpLoto.Domain.Entities;

public class JplLicense : Entity
{
    public string? UserId { get; set; } = string.Empty;
    public int PlanId { get; set; } 
    public DateTime SubscriptionDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Price { get; set; } = 0;
    public bool IsActive { get; set; } = true;
    public Plan? Plan { get; set; }
    public JplLicense(string userId, int planId, DateTime subscriptionDate, DateTime expirationDate, int price, bool isActive = true)
        : this(default, userId, planId, subscriptionDate, expirationDate, price, isActive)
    {            
    }
    public JplLicense(int id, string userId, int planId, DateTime subscriptionDate, DateTime expirationDate, int price, bool isActive = true)
    {
        Id = id;
        UserId = userId;
        PlanId = planId;
        SubscriptionDate = subscriptionDate;
        ExpirationDate = expirationDate;
        Price = price;
        IsActive = isActive;
    }
}