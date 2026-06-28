using DilcomEducationCenter.Domain.Enums;

namespace DilcomEducationCenter.Domain.Entities;

public sealed class Enrollment
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid GroupId { get; set; }
    public string? Note { get; set; }
    public EnrollmentStatus Status { get; set; }
    public DateTime EnrolledOn { get; set; }

    public Student Student { get; set; } = null!;
    public Group Group { get; set; } = null!;
    public ICollection<AssessmentResult> AssessmentResults { get; set; } = new List<AssessmentResult>();
    public ICollection<StudentAttendance> StudentAttendances { get; set; } = new List<StudentAttendance>();
}
