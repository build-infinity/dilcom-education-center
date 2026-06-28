namespace DilcomEducationCenter.Domain.Entities;

public sealed class StudentParent
{
    public Guid StudentId { get; set; }
    public Guid ParentId { get; set; }

    public Student Student { get; set; } = null!;
    public Parent Parent { get; set; } = null!; 
}