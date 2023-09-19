using JpLoto.Domain.Entities.Shared;

namespace JpLoto.Domain.Entities
{
    public class LicenseHistory : Entity
    {
        public string? UserId { get; set; } = string.Empty;
        public string? PlanCode { get; set; } = string.Empty;
        public DateTime SubscriptionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
