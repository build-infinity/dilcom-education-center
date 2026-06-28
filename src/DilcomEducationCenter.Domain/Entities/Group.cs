using DilcomEducationCenter.Domain.Enums;

namespace DilcomEducationCenter.Domain.Entities;

public sealed class Group
{
    public Guid Id { get; set; }
    public string Name  { get; set; } = null!;
    public DateOnly StartDate { get; set; } 
    public DateOnly EndDate { get; set; }
    public GroupStatus Status { get; set; }
    public short Capacity { get; set; }
    public Guid? TeacherId { get; set; }
    public Guid CourseId { get; set; }
    public DateTime UpdatedOn { get; set; }
    public DateTime CreatedOn { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public Teacher? Teacher { get; set; } = null!;
    public Course Course { get; set; } = null!;
    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    public ICollection<Assessment> Assessments { get; set; } = new List<Assessment>(); 
}