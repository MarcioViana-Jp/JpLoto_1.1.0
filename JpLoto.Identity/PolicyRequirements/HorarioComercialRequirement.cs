using Microsoft.AspNetCore.Authorization;

namespace JpLoto.Identity.PolicyRequirements
{
    public class HorarioComercialRequirement : IAuthorizationRequirement
    {
        public HorarioComercialRequirement() { }
    }
}