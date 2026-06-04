using DilcomEducationCenter.Domain.Enums;
using DilcomEducationCenter.Domain.ValueObjects;

namespace DilcomEducationCenter.Domain.Entities;

public sealed class Parent
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public Gender Gender { get; set; }
    public Email? Email { get; set; }
    public PhoneNumber PhoneNumber { get; set; } = null!; 
    public string? WorkPlace { get; set; } 
    public DateTime UpdatedOn { get; set; } 
    public DateTime CreatedOn { get; set; }

    public ICollection<StudentParent> StudentParents { get; set; } = new List<StudentParent>();
}