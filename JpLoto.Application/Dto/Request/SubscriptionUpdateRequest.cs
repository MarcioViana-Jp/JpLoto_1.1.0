using JpLoto.Domain.Entities;

namespace JpLoto.Application.Dto.Request;

public class SubscriptionUpdateRequest
{
    public int Id { get; set; }
    public string? UserId { get; set; } = string.Empty;
    public int PlanId { get; set; }
    public DateTime SubscriptionDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Price { get; set; } = 0;
    public bool IsActive { get; set; }

    public SubscriptionUpdateRequest(int id, string userId, int planId, DateTime subscriptionDate, DateTime expirationDate, int price, bool isActive)
    {
        Id = id;
        UserId = userId;
        PlanId = planId;
        SubscriptionDate = subscriptionDate;
        ExpirationDate = expirationDate;
        Price = price;
        IsActive = isActive;
    }

    public static Subscription ConvertToEntity(SubscriptionUpdateRequest request)
    {
        return new Subscription
        (
            request.Id,
            request.UserId ?? string.Empty,
            request.PlanId,
            request.SubscriptionDate,
            request.ExpirationDate,
            request.Price,
            request.IsActive
        );
    }
}