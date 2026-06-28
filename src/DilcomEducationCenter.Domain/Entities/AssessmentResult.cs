namespace DilcomEducationCenter.Domain.Entities;

public sealed class AssessmentResult
{
    public Guid EnrollmentId { get; set; }
    public Guid AssessmentId { get; set; }
    public short Score { get; set; }

    public Enrollment Enrollment { get; set; } = null!;
    public Assessment Assessment { get; set; } = null!;
}