using JpLoto.Domain.Entities.Shared;

namespace JpLoto.Domain.Entities;

public class UserDetail : Entity
{
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

    public UserDetail(string userId, string firstName, string lastName, string postalCode, string state, string city, string address, string phone, DateTime updateDate, bool isActive = true)
        : this(default, userId, firstName, lastName, postalCode, state, city, address, phone, updateDate, isActive)
    {
    }

    public UserDetail(int id, string userId, string firstName, string lastName, string postalCode, string state, string city, string address, string phone, DateTime updateDate, bool isActive = true)
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

    public UserDetail()
    {
    }
}