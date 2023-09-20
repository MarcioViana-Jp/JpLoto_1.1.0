using JpLoto.Domain.Entities.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace JpLoto.Domain.Entities;

public class Subscription : Entity
{
    public string? UserId { get; set; } = string.Empty;
    public int PlanId { get; set; } 
    public DateTime SubscriptionDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Price { get; set; } = 0;
    public bool IsActive { get; set; } = true;
    public Plan? Plan { get; private set; }

    [NotMapped]
    public bool IsOnDate { get => ExpirationDate <= DateTime.UtcNow; }
    
    public Subscription(string userId, int planId, DateTime subscriptionDate, DateTime expirationDate, int price, bool isActive = true)
        : this(default, userId, planId, subscriptionDate, expirationDate, price, isActive)
    {            
    }
    public Subscription(int id, string userId, int planId, DateTime subscriptionDate, DateTime expirationDate, int price, bool isActive = true)
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