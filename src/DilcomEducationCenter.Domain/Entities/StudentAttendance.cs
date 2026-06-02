using DilcomEducationCenter.Domain.Enums;

namespace DilcomEducationCenter.Domain.Entities;

public sealed class StudentAttendance
{
    public int EnrollmentId { get; set; }
    public int LessonId { get; set; }
    public AttendanceStatus Status { get; set; }

    public Enrollment Enrollment { get; set; } = null!; 
    public Lesson Lesson { get; set; } = null!;
}