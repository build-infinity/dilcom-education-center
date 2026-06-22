using DilcomEducationCenter.Domain.Enums;

namespace DilcomEducationCenter.Application.DTOs;

public record CreateUserRequest
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public Gender Gender { get; set; }
    public string Login { get; set;} = null!;
    public string Password { get; set; } = null!;
    public int RoleId { get; set; }
}