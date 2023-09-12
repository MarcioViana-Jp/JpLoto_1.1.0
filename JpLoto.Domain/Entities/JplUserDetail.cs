using JpLoto.Domain.Entities.Shared;
using System.ComponentModel.DataAnnotations;

namespace JpLoto.Domain.Entities;

public class JplUserDetail : Entity
{
    public string? UserId { get; set; } = string.Empty;
    public string? PostalCode { get; private set; } = string.Empty;
    public string? State { get; private set; } = string.Empty;
    public string? City { get; private set; } = string.Empty;
    public string? Address { get; private set; } = string.Empty;
    public string? Phone { get; private set; } = string.Empty;
    public DateTime UpdateDate { get; set; }
    public bool IsActive { get; set; } = true;

}