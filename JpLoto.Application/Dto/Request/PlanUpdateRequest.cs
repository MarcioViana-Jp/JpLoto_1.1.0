using JpLoto.Domain.Entities;

namespace JpLoto.Application.Dto.Request;

public class PlanUpdateRequest
{
    public int Id { get; set; }
    public string PlanCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; } = 0;
    public DateTime NotBefore { get; set; }
    public DateTime ValidThru { get; set; }
    public int ExpirationFactor { get; set; }
    public int ExpirationDescriptor { get; set; }
    public bool IsActive { get; set; }

    public PlanUpdateRequest(int id, string planCode, string description, int price, DateTime notBefore, DateTime validThru, int expirationFactor, int expirationDescriptor, bool isActive)
    {
        Id = id;
        PlanCode = planCode;
        Description = description;
        Price = price;
        NotBefore = notBefore;
        ValidThru = validThru;
        ExpirationFactor = expirationFactor;
        ExpirationDescriptor = expirationDescriptor;
        IsActive = isActive;
    }

    public static Plan ConvertToEntity(PlanUpdateRequest request)
    {
        return new Plan
        (
            request.Id,
            request.PlanCode ?? string.Empty,
            request.Description ?? string.Empty,
            request.Price,
            request.NotBefore,
            request.ValidThru,
            request.ExpirationFactor,
            request.ExpirationDescriptor,
            request.IsActive
        );
    }
}
