using JpLoto.Domain.Entities.Shared;

namespace JpLoto.Domain.Entities;

public class Plan : Entity
{
    public string? PlanCode { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string? ColorClass { get; set; } = string.Empty;
    public int Price { get; set; } = 0;
    public DateTime NotBefore { get; set; }
    public DateTime ValidThru { get; set; }
    public int ExpirationFactor { get; set; } = 0; // it willl be added to the current date to determine licence expiration
    public int ExpirationDescriptor { get; set; } = 0; // 0-day, 1-month, 2-year
    public bool IsActive { get; set; } = true;
    public ICollection<Subscription>? Subscriptions { get; private set; }
    
    public Plan(string planCode, string description, string colorClass, int price, DateTime notBefore, DateTime validThru, int expirationFactor, int expirationDescriptor, bool isActive = true )
        : this(default, planCode, description, colorClass, price, notBefore, validThru, expirationFactor, expirationDescriptor, isActive) 
    { 
    }

    public Plan(int id, string planCode, string description, string colorClass, int price, DateTime notBefore, DateTime validThru, int expirationFactor, int expirationDescriptor, bool isActive = true )
    {
        Id = id; 
        PlanCode = planCode; 
        Description = description; 
        ColorClass = colorClass;
        Price = price;
        NotBefore = notBefore; 
        ValidThru = validThru;  
        ExpirationFactor = expirationFactor;
        ExpirationDescriptor = expirationDescriptor;
        IsActive = isActive;        
    }
}