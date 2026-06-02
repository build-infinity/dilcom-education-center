using DilcomEducationCenter.Domain.Enums;

namespace DilcomEducationCenter.Domain.Entities;

public sealed class Parent
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string WorkPlace { get; set; } = null!;
    public DateTime UpdatedAt { get; set; } 
    public DateTime CreatedAt { get; set; }

    public ICollection<StudentParent> StudentParents { get; set; } = new List<StudentParent>();
}