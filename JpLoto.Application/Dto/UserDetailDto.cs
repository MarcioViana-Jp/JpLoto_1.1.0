using JpLoto.Application.Dto.Request;
using JpLoto.Application.Dto.Response;
using JpLoto.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace JpLoto.Application.Dto;

public class UserDetailDto
{
    public int Id { get; set; }
    public string? UserId { get; set; } = string.Empty;
    [StringLength(30, ErrorMessage = "O campo {0} deve ter até {1} caracteres")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string FirstName { get; set; } = string.Empty;

    [StringLength(30, ErrorMessage = "O campo {0} deve ter até {1} caracteres")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string LastName { get; set; } = string.Empty;

    [StringLength(8, ErrorMessage = "O campo {0} deve ter até {1} caracteres")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string? PostalCode { get; set; } = string.Empty;

    [StringLength(30, ErrorMessage = "O campo {0} deve ter até {1} caracteres")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string? State { get; set; } = string.Empty;

    [StringLength(30, ErrorMessage = "O campo {0} deve ter até {1} caracteres")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string? City { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "O campo {0} deve ter até {1} caracteres")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string? Address { get; set; } = string.Empty;

    [StringLength(20, ErrorMessage = "O campo {0} deve ter até {1} caracteres")]
    public string? Phone { get; set; } = string.Empty;
    public DateTime UpdateDate { get; set; }
    public bool IsActive { get; set; } = true;

    public UserDetailDto() { }
    
    public UserDetailDto(int id, string userId, string firstName, string lastName, string postalCode, string state, string city, string address, string phone, DateTime updateDate, bool isActive = true)
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

    public UserDetailDto(UserDetail userDetail)
    {
        Id = userDetail.Id;
        UserId = userDetail.UserId;
        FirstName = userDetail.FirstName;
        LastName = userDetail.LastName;
        PostalCode = userDetail.PostalCode;
        State = userDetail.State;
        City = userDetail.City;
        Address = userDetail.Address;
        Phone = userDetail.Phone;
        UpdateDate = userDetail.UpdateDate;
        IsActive = userDetail.IsActive;
    }

    public UserDetailDto(UserDetailResponse response)
    {
        Id = response.Id;
        UserId = response.UserId;
        FirstName = response.FirstName;
        LastName = response.LastName;
        PostalCode = response.PostalCode;
        State = response.State;
        City = response.City;
        Address = response.Address;
        Phone = response.Phone;
        UpdateDate = response.UpdateDate;
        IsActive = response.IsActive;
    }
    
    public UserDetail ConvertToEntity()
    {
        return new UserDetail(
            Id, UserId, FirstName, LastName, PostalCode, State, City, Address, Phone, UpdateDate, IsActive
        );
    }

    public UserDetail ConvertToEntityWithoutId()
    {
        return new UserDetail(
            UserId, FirstName, LastName, PostalCode, State, City, Address, Phone, UpdateDate, IsActive
        );
    }

    public static UserDetail ToEntity(UserDetailDto dto)
    {
        return new UserDetail(
            dto.Id, 
            dto.UserId,
            dto.FirstName,
            dto.LastName,
            dto.PostalCode,
            dto.State,
            dto.City,
            dto.Address,
            dto.Phone,
            dto.UpdateDate,
            dto.IsActive
        );
    }

    public static UserDetail ToEntityWithoutId(UserDetailDto dto)
    {
        return new UserDetail(
            dto.UserId,
            dto.FirstName,
            dto.LastName,
            dto.PostalCode,
            dto.State,
            dto.City,
            dto.Address,
            dto.Phone,
            dto.UpdateDate,
            dto.IsActive
        );
    }

    public UserDetailAddRequest ConvertToAddRequest()
    {
        return new UserDetailAddRequest(
            UserId, FirstName, LastName, PostalCode, State, City, Address, Phone, UpdateDate
        );
    }

    public UserDetailUpdateRequest ConvertToUpdateRequest()
    {
        return new UserDetailUpdateRequest(
            Id, UserId, FirstName, LastName, PostalCode, State, City, Address, Phone, UpdateDate
        );
    }

}