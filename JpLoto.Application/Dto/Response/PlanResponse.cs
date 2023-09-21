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

    public static PlanResponse ConvertToResponse(Plan response)
    {
        return new PlanResponse
        (
            response.Id,
            response.PlanCode ?? string.Empty,
            response.Description ?? string.Empty,
            response.ColorClass ?? string.Empty,
            response.Price,
            response.NotBefore,
            response.ValidThru,
            response.ExpirationFactor,
            response.ExpirationDescriptor,
            response.IsActive
        );
    }
}
