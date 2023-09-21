using JpLoto.Domain.Entities;

namespace JpLoto.Application.Dto.Request;

public class PlanAddRequest
{
    public string PlanCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ColorClass { get; set; } = string.Empty;
    public int Price { get; set; } = 0;
    public DateTime NotBefore { get; set; }
    public DateTime ValidThru { get; set; }
    public int ExpirationFactor { get; set; } = 0;
    public int ExpirationDescriptor { get; set; } = 0;

    public PlanAddRequest(string planCode, string description, string colorClass, int price, DateTime notBefore, DateTime validThru, int expirationFactor, int expirationDescriptor)
    {
        PlanCode = planCode;
        Description = description;
        ColorClass = colorClass;
        Price = price;
        NotBefore = notBefore;
        ValidThru = validThru;
        ExpirationFactor = expirationFactor;
        ExpirationDescriptor = expirationDescriptor;
    }

    public static Plan ConvertToEntity(PlanAddRequest request)
    {
        return new Plan
        (
            request.PlanCode ?? string.Empty,
            request.Description ?? string.Empty,
            request.ColorClass ?? string.Empty,
            request.Price,
            request.NotBefore,
            request.ValidThru,
            request.ExpirationFactor,
            request.ExpirationDescriptor,
            true  // IsActive is set to 'true'
        );
    }
}