using JpLoto.Domain.Entities;

namespace JpLoto.Application.Dto.Response;

public class PlanResponse
{
    public int Id { get; set; }
    public string PlanCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ColorClass { get; set; } = string.Empty;
    public int Price { get; set; } = 0;
    public DateTime NotBefore { get; set; }
    public DateTime ValidThru { get; set; }
    public int ExpirationFactor { get; set; } = 0;
    public int ExpirationDescriptor { get; set; } = 0;
    public bool IsActive { get; set; } = true;

    public PlanResponse(int id, string planCode, string description, string colorClass, int price, DateTime notBefore, DateTime validThru, int expirationFactor, int expirationDescriptor, bool isActive)
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

    public static PlanResponse ConvertToResponse(Plan plan)
    {
        return new PlanResponse
        (
            plan.Id,
            plan.PlanCode ?? string.Empty,
            plan.Description ?? string.Empty,
            plan.ColorClass ?? string.Empty,
            plan.Price,
            plan.NotBefore,
            plan.ValidThru,
            plan.ExpirationFactor,
            plan.ExpirationDescriptor,
            plan.IsActive
        );
    }
}
