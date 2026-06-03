using DilcomEducationCenter.Domain.Enums;
using DilcomEducationCenter.Domain.ValueObjects;

namespace DilcomEducationCenter.Domain.Entities;

public sealed class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Gender Gender { get; set; }
    public DateOnly BirthDate { get; set; }
    public Email Email { get; set; } = null!;
    public DateTime UpdatedOn { get; set; }
    public DateTime CreatedOn { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public ICollection<StudentParent> StudentParents { get; set; } = new List<StudentParent>();
}