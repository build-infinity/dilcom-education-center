namespace DilcomEducationCenter.Domain.Entities;

public sealed class Teacher
{
    public Guid Id { get; set; }
    public string Education { get; set; } = null!;
    public string Degree { get; set; } = null!;
    public string? Majority { get; set; } = null!; 
    public decimal Salary { get; set; }
    public short ExperienceInYears { get; set; }
    public DateOnly HiredOn { get; set; }
    public Guid UserId { get; set; }
    public DateTime UpdatedOn { get; set; }
    public DateTime CreatedOn { get; set; }

    public User User { get; set; } = null!;    
    public ICollection<Group> Groups { get; set; } = new List<Group>();
    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}