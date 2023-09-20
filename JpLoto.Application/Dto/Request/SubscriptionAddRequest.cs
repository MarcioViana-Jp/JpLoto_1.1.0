using JpLoto.Domain.Entities;

namespace JpLoto.Application.Dto.Request;

public class SubscriptionAddRequest
{
    public string? UserId { get; set; } = string.Empty;
    public int PlanId { get; set; }
    public DateTime SubscriptionDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Price { get; set; } = 0;

    public SubscriptionAddRequest(string userId, int planId, DateTime subscriptionDate, DateTime expirationDate, int price)
    {
        UserId = userId;
        PlanId = planId;
        SubscriptionDate = subscriptionDate;
        ExpirationDate = expirationDate;
        Price = price;
    }

    public static Subscription ConvertToEntity(SubscriptionAddRequest request)
    {
        return new Subscription
        (
            request.UserId ?? string.Empty,
            request.PlanId,
            request.SubscriptionDate,
            request.ExpirationDate,
            request.Price,
            true  // IsActive is set to 'true'
        );
    }
}