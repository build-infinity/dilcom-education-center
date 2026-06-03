using DilcomEducationCenter.Domain.Enums;
using DilcomEducationCenter.Domain.ValueObjects;

namespace DilcomEducationCenter.Domain.Entities;

public sealed class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly BirthDate { get; set;}
    public Email Email { get; set; } = null!;
    public Gender Gender { get; set; }
    public string Login { get; set;} = null!;
    public string PasswordHash { get; set; } = null!;
    public int RoleId { get; set; }
    public DateTime UpdatedOn { get; set; }
    public DateTime CreatedOn { get; set; }

    public Role Role { get; set; } = null!;
    public Teacher? Teacher { get; set; }
}
