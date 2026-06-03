namespace DilcomEducationCenter.Domain.Entities;

public sealed class TimeSlot
{
    public int Id { get; set; }
    public string Name { get; set; } = null!; 
    public TimeOnly StartTime { get; set; } 
    public TimeOnly EndTime { get; set; }
    public DateTime CreatedOn { get; set; } 
}