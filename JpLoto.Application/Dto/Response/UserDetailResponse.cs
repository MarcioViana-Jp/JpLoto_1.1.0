using JpLoto.Domain.Entities;

namespace JpLoto.Application.Dto.Response;

public class UserDetailResponse
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime UpdateDate { get; set; }
    public bool IsActive { get; set; } = true;

    public UserDetailResponse(int id, string userId, string firstName, string lastName, string postalCode, string state, string city, string address, string phone, DateTime updateDate, bool isActive)
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
        IsActive = isActive;
    }

    public UserDetailResponse() { }

    public static UserDetailResponse ConvertToResponse(UserDetail detail)
    {
        return new UserDetailResponse
        (
            detail.Id,
            detail.UserId ?? string.Empty,
            detail.FirstName ?? string.Empty,
            detail.LastName ?? string.Empty,
            detail.PostalCode ?? string.Empty,
            detail.State ?? string.Empty,
            detail.City ?? string.Empty,
            detail.Address ?? string.Empty,
            detail.Phone ?? string.Empty,
            detail.UpdateDate,
            detail.IsActive
        );
    }
}

