using JpLoto.Domain.Entities;

namespace JpLoto.Application.Dto.Response;

public class SubscriptionResponse
{
    public int Id { get; set; }
    public string? UserId { get; set; } = string.Empty;
    public int PlanId { get; set; }
    public DateTime SubscriptionDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Price { get; set; } = 0;
    public bool IsActive { get; set; }

    public SubscriptionResponse(int id, string userId, int planId, DateTime subscriptionDate, DateTime expirationDate, int price, bool isActive)
    {
        Id = id;
        UserId = userId;
        PlanId = planId;
        SubscriptionDate = subscriptionDate;
        ExpirationDate = expirationDate;
        Price = price;
        IsActive = isActive;
    }

    public static SubscriptionResponse ConvertToResponse(Subscription response)
    {
        return new SubscriptionResponse
        (
            response.Id,
            response.UserId ?? string.Empty,
            response.PlanId,
            response.SubscriptionDate,
            response.ExpirationDate,
            response.Price,
            response.IsActive
        );
    }
}
