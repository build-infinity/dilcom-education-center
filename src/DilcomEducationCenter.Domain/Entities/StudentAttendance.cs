using DilcomEducationCenter.Domain.Enums;

namespace DilcomEducationCenter.Domain.Entities;

public sealed class StudentAttendance
{
    public Guid EnrollmentId { get; set; }
    public Guid LessonId { get; set; }
    public AttendanceStatus Status { get; set; }

    public Enrollment Enrollment { get; set; } = null!; 
    public Lesson Lesson { get; set; } = null!;
}