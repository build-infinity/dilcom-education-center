namespace DilcomEducationCenter.Domain.Entities;

public sealed class Assessment
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public short OrderNo { get; set; }
    public int GroupId { get; set; }
    public DateTime Date { get; set; }
    
    public Group Group { get; set; } = null!;
    public ICollection<AssessmentResult> AssessmentResults { get; set; } = new List<AssessmentResult>();
}