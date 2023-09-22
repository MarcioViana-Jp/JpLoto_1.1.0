using JpLoto.Domain.Entities;

namespace JpLoto.Application.Dto.Request;

public class UserDetailUpdateRequest
{
    public int Id { get; set; }
    public string? UserId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? PostalCode { get; private set; } = string.Empty;
    public string? State { get; private set; } = string.Empty;
    public string? City { get; private set; } = string.Empty;
    public string? Address { get; private set; } = string.Empty;
    public string? Phone { get; private set; } = string.Empty;
    public DateTime UpdateDate { get; set; }
    public bool IsActive { get; set; } = true;

    public UserDetailUpdateRequest(int id, string userId, string firstName, string lastName, string postalCode, string state, string city, string address, string phone, DateTime updateDate)
    {
        Id = id;
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        PostalCode = postalCode;
        State = state;
        City = city;
        Address = address;
        Phone = phone;
        UpdateDate = updateDate;
    }

    public static JplUserDetail ConvertToEntity(UserDetailUpdateRequest request)
    {
        return new JplUserDetail
        (
            request.Id,
            request.UserId ?? string.Empty,
            request.FirstName ?? string.Empty,
            request.LastName ?? string.Empty,
            request.PostalCode ?? string.Empty,
            request.State ?? string.Empty,
            request.City ?? string.Empty,
            request.Address ?? string.Empty,
            request.Phone ?? string.Empty,
            request.UpdateDate,
            request.IsActive
        );
    }
}

